using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //si queremos crear las tablas en la BD a partir de la entidad, si no no agregar
        public DbSet<Lugar> Lugar {get;set;}
        public DbSet<Categoria> Categoria {get;set;}

        public DbSet<Pais> Pais {get;set;}
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)//Es el metodo encargado de crear las migraciones
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}