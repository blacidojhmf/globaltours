using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Datos;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.interfaces;
using Core.Especificaciones;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        //Esta referencia comentada es cuando se usa un repositorio identificado con una entidad
        // public ILugarRepositorio _lugarRepo;

        // public LugaresController(ILugarRepositorio repo)
        // {
        //     _lugarRepo = repo;
        // }


        //Ejemplo de uso de un repositorio Generico donde le mandamos la clase de entidad
        public IRepositorio<Lugar> _lugarRepo;
        public IRepositorio<Pais> _paisRepo { get; }
        public IRepositorio<Categoria> _categoriaRepo { get; }
        public IMapper _mapper { get; }

        public LugaresController(IRepositorio<Lugar> lugarRepo, IRepositorio<Pais> paisRepo, IRepositorio<Categoria> categoriaRepo, IMapper mapper)
        {
            _mapper = mapper;
            _categoriaRepo = categoriaRepo;
            _paisRepo = paisRepo;
            _lugarRepo = lugarRepo;
            
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<LugarDto>>> GetLugares()// de Task<ActionResult<Lugar>> a Task<ActionResult<LugarDto>>
        {
            //Las especificaciones son los joins
            var espec = new LugaresConPaisCategoriaEspecificacion();
            var lugares = await _lugarRepo.ObtnerTodosEspecificacion(espec);
            return Ok(_mapper.Map<IReadOnlyList<Lugar>, IReadOnlyList<LugarDto>>(lugares));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LugarDto>> GetLugar(int id)// de Task<ActionResult<Lugar>> a Task<ActionResult<LugarDto>>
        {
            //LugaresConPaisCategoriaEspecificacion es el constructor que recibe un parametro
            var espec = new LugaresConPaisCategoriaEspecificacion(id);
            var lugar = await _lugarRepo.ObtenerEspecificacion(espec);
            return _mapper.Map<Lugar,LugarDto>(lugar);
          
        }

        [HttpGet("paises")]
        public async Task<ActionResult<List<Pais>>> GetPaises(){
            return Ok(await _paisRepo.ObtenerTodosAsync());
        }

        [HttpGet("categoria")]
        public async Task<ActionResult<List<Categoria>>> GetCategoria(){
            return Ok(await _categoriaRepo.ObtenerTodosAsync());
        }

    }
}