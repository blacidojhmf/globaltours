using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Especificacion;

namespace Core.Especificaciones
{
    public class LugaresConPaisCategoriaEspecificacion : EspecificacionBase<Lugar>
    {
        //AgregarInclude esta en la clase EspecificacionBase 
        //Para la funcion ObtnerTodosEspecificacion
        public LugaresConPaisCategoriaEspecificacion()
        {
            AgregarInclude(x => x.Pais);
            AgregarInclude(x => x.Categoria);
        }

        public LugaresConPaisCategoriaEspecificacion(int id) : base(x => x.id == id)
        {
            AgregarInclude(x => x.Pais);
            AgregarInclude(x => x.Categoria);
        }
    }
}