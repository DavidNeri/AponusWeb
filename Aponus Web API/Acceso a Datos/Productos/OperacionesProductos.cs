using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
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

        internal void GuardarComponententesCuantitativos(DatosProducto producto, ComponentesProducto componente)
        {
            try
            {
                if (componente.Cantidad!=null)
                {
                    componente.Cantidad = 0;

                }

                AponusDBContext.ComponentesCuantitativos
                       .Add(new ComponentesCuantitativo
                       {
                           IdProducto = producto.IdProducto,
                           IdComponente = componente.IdComponente,
                           Cantidad = (int)componente.Cantidad
                           
                       });

            }
            catch (Exception)
            {


            }
        }

        internal void GuardarComponententesMensurables(DatosProducto producto, ComponentesProducto componente)
        {
            try
            {
                AponusDBContext.ComponentesMensurables
                    .Add(new ComponentesMensurable
                    {
                        IdProducto = producto.IdProducto,                        
                        IdComponente = componente.IdComponente,
                        Largo=componente.Largo,
                        
                    });
            }
            catch (Exception)
            {


            }
        }

        internal void GuardarComponententesPesables(DatosProducto producto, ComponentesProducto componente)
        {
            try
            {
                AponusDBContext.ComponentesPesables
                    .Add(new ComponentesPesable
                    {
                        IdProducto = producto.IdProducto,
                        IdComponente = componente.IdComponente,
                        Cantidad = componente.Cantidad,
                        Peso = componente.Peso
                    });
            }
            catch (Exception)
            {

                
            }
        }

        internal void GuardarProducto(DatosProducto producto)
        {
           
            try
            {

              
                    AponusDBContext.Productos
                   .Add(new Producto
                   {
                       IdProducto = GenerarIdProd(producto),
                       IdDescripcion = (int)producto.IdDescripcion,
                       IdTipo = producto.IdTipo,
                       DiametroNominal = producto.DiametroNominal,
                       Cantidad = producto.Cantidad,
                       Precio = producto.Precio,
                       Tolerancia = producto.Tolerancia,

                   });
                
               

               
            }
            catch (Exception)
            {


            }
        }

        private string GenerarIdProd(DatosProducto Producto)
        {
            string IdProducto = "";

            try
            {
                string Tolerancia = Regex.Replace(IdProducto, "-/", "-");
                IdProducto = Producto.IdTipo + "_" + Producto.IdDescripcion + "_" + Producto.DiametroNominal + "_" + Tolerancia;
            }
            catch (Exception)
            {

                return null;
            }

            return  IdProducto;
        }
    }
}
