using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificacion;

namespace Core.interfaces
{
    public interface IRepositorio<T> where T: class
    {
        Task<T> ObtenerAsync(int id);
        Task<IReadOnlyList<T>> ObtenerTodosAsync();

        Task<T> ObtenerEspecificacion(IEspecificacion<T> especificacion);

        Task<IReadOnlyList<T>> ObtnerTodosEspecificacion(IEspecificacion<T> especificacion);

    }
}