using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Datos.Config
{

    //Esta clase permite configurar los campos de las tablas cuando se realiza la migracion
    public class LugarConfiguration : IEntityTypeConfiguration<Lugar>
    {
        public void Configure(EntityTypeBuilder<Lugar> builder)
        {
            builder.Property(l=>l.id).IsRequired();
            builder.Property( l => l.Nombre).HasMaxLength(100);
            builder.Property(l=>l.Descripcion).IsRequired();
            builder.Property(l => l.GastoAproximado).IsRequired();

            //controlar las relaciones
            builder.HasOne(c=> c.Categoria).WithMany().HasForeignKey(l => l.CategoriaId);
            builder.HasOne(c=>c.Pais).WithMany().HasForeignKey(l => l.PaisId);

            //Sobre escribir el metodo OnModelCreating en ApplicationDbContext
        }
    }
}