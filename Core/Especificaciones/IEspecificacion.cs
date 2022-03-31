using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Especificacion
{
    //Esta clase va a permitir crear los filtrospara el repositorio generico IRepositorio
    public interface IEspecificacion<T>
    {
        Expression<Func<T,bool>> Filtro {get;}
        List<Expression<Func<T,object>>> Includes {get;}
    }
}