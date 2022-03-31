using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entidades;

namespace API.Helper
{
    //Agregar Este servicio en Program.cs
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            //con FormMeber vamos  indicar que todo lo que esa en Lugar como Pais y Categoria, se va a mostrar en LugarDto String Pais y String Categoria
            CreateMap<Lugar,LugarDto>()
            .ForMember(d => d.Pais, o => o.MapFrom( s => s.Pais.Nombre ))
            .ForMember( d => d.Categoria, o=>o.MapFrom( s => s.Categoria.Nombre))
            .ForMember( d=> d.ImagenUrl, o=>o.MapFrom<LugarUrlResolver>());//Accede a la ruta de la imagen y lo amarra con el dato de la BD

        }
    }
}