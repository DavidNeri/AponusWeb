using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Aponus_Web_API.Acceso_a_Datos.Productos
{
    
    public class OperacionesProductos
    {
        private readonly AponusContext AponusDBContext;
        public OperacionesProductos() { AponusDBContext = new AponusContext(); }
        internal void EliminarComponententesCuantitativos(DatosProducto producto, List<ComponentesProducto> componentes)
        {
            throw new NotImplementedException();
        }

        internal void EliminarComponententesMensurables(DatosProducto producto, List<ComponentesProducto> componentes)
        {
            throw new NotImplementedException();
        }

        internal void EliminarComponententesPesables(DatosProducto producto, List<ComponentesProducto> componentes)
        {
            throw new NotImplementedException();
        }

        internal void EliminarProducto(DatosProducto producto)
        {
            throw new NotImplementedException();
        }

        internal void GuardarComponententesCuantitativos(ComponentesProducto componente)
        {
            AponusDBContext.ComponentesCuantitativos
                   .Add(new ComponentesCuantitativo
                   {
                       IdProducto = componente.IdProducto,
                       IdComponente = componente.IdComponente,
                       Cantidad = (int)componente.Cantidad

                   });

            AponusDBContext.SaveChanges();
                      
        }

        internal void GuardarComponententesMensurables(ComponentesProducto componente)
        {
            AponusDBContext.ComponentesMensurables
                .Add(new ComponentesMensurable
                {
                    IdProducto = componente.IdProducto,
                    IdComponente = componente.IdComponente,
                    Largo = componente.Largo,

                });
            AponusDBContext.SaveChanges(); 
        }

        internal void GuardarComponententesPesables(ComponentesProducto componente)
        {

            AponusDBContext.ComponentesPesables
                   .Add(new ComponentesPesable
                   {
                       IdProducto = componente.IdProducto,
                       IdComponente = componente.IdComponente,
                       Cantidad = componente.Cantidad,
                       Peso = componente.Peso
                   });
            AponusDBContext.SaveChanges();

        }

        internal void GuardarProducto(GuardarProducto producto)
        {

            AponusDBContext.Productos
             .Add(new Producto
             {
                 IdProducto = producto.Producto.IdProducto,
                 IdDescripcion = (int)producto.Producto.IdDescripcion,
                 IdTipo = producto.Producto.IdTipo,
                 DiametroNominal = producto.Producto.DiametroNominal,
                 Cantidad = producto.Producto.Cantidad,
                 Precio = producto.Producto.Precio,
                 Tolerancia = producto.Producto.Tolerancia,

             });

            AponusDBContext.SaveChanges();
        }

        public string GenerarIdProd(GuardarProducto Producto)
        {
            string IdProducto = "";

            try
            {
                string Tolerancia = Producto.Producto.Tolerancia.Replace("-", "_").Replace("/","_");
                IdProducto = Producto.Producto.IdTipo + "_" +
                    Producto.Producto.IdDescripcion + "_" +
                    Producto.Producto.DiametroNominal + "_" + Tolerancia;
            }
            catch (Exception)
            {

                return null;
            }

            return IdProducto;
        }
    }
}
