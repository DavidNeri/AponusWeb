using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Microsoft.EntityFrameworkCore;

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
            //Crear tabla unir tipos y descripcion
            //generar id tipo
            //Guardar TIPO PROD
            //guardar descripcion
            //GuardarProd
            try
            {

                if (producto.IdDescripcion!=null) //Nuncadeberia ser null, me la pasa franco
                {
                    AponusDBContext.Productos
                   .Add(new Producto
                   {
                       IdProducto = producto.IdProducto,//Generar ID_Producto
                       IdDescripcion = (int)producto.IdDescripcion,
                       IdTipo = producto.IdTipo,
                       DiametroNominal = producto.DiametroNominal,
                       Cantidad = producto.Cantidad,
                       Precio=producto.Precio,
                       Tolerancia = producto.Tolerancia,

                   });
                }
                else
                {
                    //Agregar Descripcion en tabla Descripciion_Prodcutos
                }

               
            }
            catch (Exception)
            {


            }
        }
    }
}
