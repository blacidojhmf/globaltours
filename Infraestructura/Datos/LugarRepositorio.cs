using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class LugarRepositorio : ILugarRepositorio
    {
        private readonly ApplicationDbContext _db;

        public LugarRepositorio(ApplicationDbContext db)
        {
            _db = db;

        }


        //Para cargar la data relacionada en de pais y Lugar se debe anadir los includ, siempre y cuando en el modelo este relacionado
        //Cambiar de FindAsync(id) a 
        public async Task<Lugar> GetLugarAsync(int id)
        {
            return await _db.Lugar
                    .Include(p => p.Pais)
                    .Include(c => c.Categoria)
                    .FirstOrDefaultAsync(l => l.id == id);

        }

        public async Task<IReadOnlyList<Lugar>> GetLugaresAsync()
        {
            var list = await _db.Lugar
            .Include(p => p.Pais)
            .Include(c => c.Categoria)
            .ToListAsync();
            return list;
        }
    }
}