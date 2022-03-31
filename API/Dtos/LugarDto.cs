using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    //Agregar con nugget AutoMapper.Extensions.Microsoft.DependencyInjection y el Directorio Helper para el mapeo
    //builder.Services.AddAutoMapper(typeof(MappingProfiles));
    public class LugarDto
    {
        public int id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public double GastoAproximado { get; set; }

        public string ImagenUrl { get; set; }

        public String Pais { get; set; }

        public String Categoria { get; set; }
    }
}