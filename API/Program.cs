using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//agregar el servicio q permita conectar el dbcontext con la cadena de conexion agregado en appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefautConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
