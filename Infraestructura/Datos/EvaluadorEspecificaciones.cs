using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificacion;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    //Debes crear la clase IEspecificacion y EspecificacionBase
    public class EvaluadorEspecificaciones<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IEspecificacion<T> espec){
            var query = inputQuery;
            if(espec.Filtro != null){
                query = query.Where(espec.Filtro); //Lo que hace: p = p.PaisId = 1;
            }
            //estsos includes son las joins a las entidades relacionadas
            query = espec.Includes.Aggregate(query, (current, include)=> current.Include(include));
            return query;
        }
    }
}