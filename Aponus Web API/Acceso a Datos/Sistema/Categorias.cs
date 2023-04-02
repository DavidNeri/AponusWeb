using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Acceso_a_Datos.Sistema

{
    public class Categorias
    {
        private readonly AponusContext AponusDBContext;
        public Categorias() { AponusDBContext = new AponusContext(); }

        internal List<Descripciones> ListarDescripciones(string idTipo)
        {
            List<Descripciones> Descripciones = AponusDBContext.ProductosDescripcions
                .Join(AponusDBContext.Producto_Tipo_Descripcion,
                _Descripciones => _Descripciones.IdDescripcion, _Tipo => _Tipo.IdDescripcion,
                (_Descripciones, _Tipo) => new {
                    _idTipo= _Tipo.IdTipo,
                    _Descripciones.IdDescripcion,
                    _Descripciones.DescripcionProducto
                })
                .Where(Tipo=>Tipo._idTipo==idTipo)
                .Select(x=> new Descripciones { IdDescripcion=x.IdDescripcion,Descripcion=x.DescripcionProducto })
                .ToList();

            return Descripciones ;

        }
    }
}
