using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.interfaces
{
    public interface ILugarRepositorio
    {
        //firmas de nuestros metodos
        Task<Lugar> GetLugarAsync(int id);
        Task<IReadOnlyList<Lugar>> GetLugaresAsync();//IReadOnlyList en ves List, pq solo es una lista de lectura
        
    }
}