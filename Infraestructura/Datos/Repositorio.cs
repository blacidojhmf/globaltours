using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificacion;
using Core.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    //Luego inyectarlo en Program.cs
    //builder.Services.AddScoped(typeof(IRepositorio<>),(typeof(Repositorio<>)))
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        public ApplicationDbContext _db { get; }

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<T> ObtenerAsync(int id)
        {
           return await _db.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        //Para estos metodos debes crear las clases de IEspecificacion, EspecificacionBase y EvaluadorEspecificaciones
        public async Task<T> ObtenerEspecificacion(IEspecificacion<T> especificacion)
        {
            return await AplicarEspeficicacion(especificacion).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ObtnerTodosEspecificacion(IEspecificacion<T> especificacion)
        {
            return await AplicarEspeficicacion(especificacion).ToListAsync();
        }

        //Este metodo se va a encargar de aplicar todas las especificaciones
        private IQueryable<T>  AplicarEspeficicacion(IEspecificacion<T> especificacion){
            //Set<T> remplaza al monbre de la entidad ejem _db.Lugar
            return EvaluadorEspecificaciones<T>.GetQuery(_db.Set<T>().AsQueryable(), especificacion);
        }
    }
}