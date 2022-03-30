using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Datos;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        public ILugarRepositorio _repositorio;

        public LugaresController(ILugarRepositorio repo)
        {
            _repositorio = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lugar>>> GetLugares(){
            var lugares = await _repositorio.GetLugaresAsync();
            return Ok(lugares);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lugar>> GetLugar(int id){
            var lugar = await _repositorio.GetLugarAsync(id);
            return lugar;
        }
        
    }
}