using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Acceso_a_Datos.Sistema

{
    public class Categorias
    {
        private readonly AponusContext AponusDBContext;
        public Categorias() { AponusDBContext = new AponusContext(); }

      

        internal List<DTODescripciones> ListarDescripciones(string idTipo)
        {
            List<DTODescripciones> Descripciones = AponusDBContext.ProductosDescripcions
                .Join(AponusDBContext.Producto_Tipo_Descripcion,
                _Descripciones => _Descripciones.IdDescripcion, _Tipo => _Tipo.IdDescripcion,
                (_Descripciones, _Tipo) => new {
                    _idTipo= _Tipo.IdTipo,
                    _Descripciones.IdDescripcion,
                    _Descripciones.DescripcionProducto
                })
                .Where(Tipo=>Tipo._idTipo==idTipo)
                .Select(x=> new DTODescripciones { IdDescripcion=x.IdDescripcion,Descripcion=x.DescripcionProducto })
                .ToList();

            return Descripciones ;

        }

        internal int? NuevaDescripcion(DTOCategorias nuevaCategoria)
        {

            AponusDBContext.ProductosDescripcions
                .Add(new ProductosDescripcion {
                            IdDescripcion = null,
                            DescripcionProducto = nuevaCategoria.Descripcion });
            AponusDBContext.SaveChanges();


            int? IdDescripcion = AponusDBContext.ProductosDescripcions
                .Where(x => x.DescripcionProducto == nuevaCategoria.DescripcionTipo)
                .Select(x => x.IdDescripcion).FirstOrDefault();
            return IdDescripcion;


        }

        internal void NuevoTipo(DTOCategorias NuevaCategoria)
        {
            AponusDBContext.ProductosTipos.
                Add(new ProductosTipo{
                    IdTipo = NuevaCategoria.IdTipo,
                    DescripcionTipo = NuevaCategoria.DescripcionTipo
                });

            AponusDBContext.SaveChanges();
                
        }

        internal void VincularCatgorias(DTOCategorias nuevaCategoria)
        {
            AponusDBContext.Producto_Tipo_Descripcion
                .Add(new Productos_Tipos_Descripcion
                {
                    IdTipo = nuevaCategoria.IdTipo,
                    IdDescripcion = nuevaCategoria.IdDescripcion
                });
            AponusDBContext.SaveChanges();

        }
    }
}
