using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Especificacion
{
    //Esta clase vaa implementar los metodos de la interface Core/Especificaciones/IEspecificacion
    public class EspecificacionBase<T> : IEspecificacion<T>
    {

        public EspecificacionBase(Expression<Func<T, bool>> filtro)
        {
            Filtro = filtro;
        }

        //constructor sin parametros usado en LugaresConPaisCategoriaEspecificacion
        public EspecificacionBase()
        {
            
        }

        public Expression<Func<T, bool>> Filtro { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();//iniciamos la lista varia

        protected void AgregarInclude(Expression<Func<T,object>> includeExpression){
            Includes.Add(includeExpression);
        }

    }
}