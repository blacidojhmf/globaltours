using API.Helper;
using Core.interfaces;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
//agregar el servicio q permita conectar el dbcontext con la cadena de conexion agregado en appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefautConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectamos el repositorio
builder.Services.AddScoped<ILugarRepositorio, LugarRepositorio>();
builder.Services.AddScoped(typeof(IRepositorio<>),(typeof(Repositorio<>)));//typeof por que no tiene un tipo de datos(entidad)
builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

//Aplicar las nuevas migraciones al ejecutar la aplicacion
using(var scopre = app.Services.CreateScope()){
    var services = scopre.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try{
        var context = services.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();
        await BaseDatosSeed.SeedAsync(context,loggerFactory);//ejecutamos la carga de datos
    }catch(System.Exception ex){
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Un error ocurrio durante la migracion");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Manejar archivos estaticos para acceder a la carpeta de imagenes, Ref: Folder wwwroot y MappingProfiles

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
