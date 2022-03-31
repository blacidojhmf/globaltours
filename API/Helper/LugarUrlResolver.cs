using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entidades;

namespace API.Helper
{
    public class LugarUrlResolver : IValueResolver<Lugar, LugarDto, string>
    {
        public IConfiguration _configuration { get; }

        //nos va a permitir acceder a la url declarado en appsetting
        public LugarUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string Resolve(Lugar source, LugarDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImagenUrl)){
                return _configuration["ApiUrl"] + source.ImagenUrl;
            }
            return null;
        }
    }
}