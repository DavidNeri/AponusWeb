using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Microsoft.Build.Framework;
using Aponus_Web_API.Services;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Acceso_a_Datos.Productos;
using Aponus_Web_API.Acceso_a_Datos.Insumos;
using Aponus_Web_API.Data_Transfer_Objects;
using Microsoft.Data.SqlClient;

namespace Aponus_Web_API.Business
{
    public class BS_Products 
    {
        public JsonResult ListarInsumos(string ProductId, int Cantidad)
        {
            
            try
            {
                List<Insumos> InusmoPesables = new ObtenerInsumos().ObtenterPesables(ProductId, Cantidad);
                List<Insumos> InusmoCuantitativos= new ObtenerInsumos().ObtenterCuantitativos(ProductId, Cantidad);
                List<Insumos> InusmoMensurables = new ObtenerInsumos().ObtenterMensurables(ProductId, Cantidad);

                InsumosProducto _InsumosProducto = new InsumosProducto()
                {
                    Pesables = InusmoPesables,
                    Cuantitativos= InusmoCuantitativos,
                    Mensurables= InusmoMensurables

                };

                return new JsonResult(_InsumosProducto);
            }
            catch (Exception e)
            {

                return new JsonResult(e);
            }


        }

        internal void GuardarProducto(GuardarProducto producto)
        {
            OperacionesProductos operacionesProductos = new OperacionesProductos();

           // try
           // {
                producto.Producto.IdProducto= operacionesProductos.GenerarIdProd(producto); //Coorejir

               // operacionesProductos.GuardarProducto(producto);
            foreach (ComponentesProducto Componente in producto.Componentes)
            {

                switch (new TablaInsumo().ObtenerTabla(new Insumos { IdInsumo = Componente.IdComponente }))
                {
                    case 0:
                        Componente.IdProducto = producto.Producto.IdProducto;
                        operacionesProductos.GuardarComponententesPesables(Componente);

                        break;
                    case 1:
                        Componente.IdProducto = producto.Producto.IdProducto;

                        operacionesProductos.GuardarComponententesCuantitativos(Componente);
                        break;

                    case 2:
                        Componente.IdProducto = producto.Producto.IdProducto;
                        operacionesProductos.GuardarComponententesMensurables(Componente);
                        break;
                    default:
                        break;
                }
            }

            /*   foreach (ComponentesProducto Componente in producto.Componentes)
               { 

                   switch (new TablaInsumo().ObtenerTabla(new Insumos { IdInsumo = Componente.IdComponente }))
                   {
                       case 0:
                           Componente.IdProducto = producto.Producto.IdProducto;
                           operacionesProductos.GuardarComponententesPesables(Componente);

                           break;
                       case 1:
                           Componente.IdProducto = producto.Producto.IdProducto;

                           operacionesProductos.GuardarComponententesCuantitativos(Componente);
                           break;

                       case 2:
                           Componente.IdProducto = producto.Producto.IdProducto;
                           operacionesProductos.GuardarComponententesMensurables(Componente);
                           break;
                       default:
                           break;
                   }


               }
               return new StatusCodeResult(StatusCodes.Status200OK);*/


            // }
            //  catch (DbUpdateException e)
            //  {
            //    string Mensaje = e.Message;
            //
            //    return new ForbidResult(Mensaje);

            // operacionesProductos.EliminarComponententesPesables(producto, Componentes);
            // operacionesProductos.EliminarComponententesCuantitativos(producto, Componentes);
            //operacionesProductos.EliminarComponententesMensurables(producto, Componentes);
            //operacionesProductos.EliminarProducto(producto);


            // }





        }

        internal  async Task<JsonResult> ListarDN(string? typeId)
        {
             return await new  ObtenerProductos().ListarDN(typeId);
        }

        internal JsonResult ListarProductos(string? TypeId) {

            return new ObtenerProductos().Listar(TypeId);

        }

        internal JsonResult ListarProductos()
        {
            return new ObtenerProductos().Listar();
        }

        internal Task<DatosProducto> ListarProductos(string? typeId, int? dN)
        {
            return new ObtenerProductos().Listar(typeId, dN);
        }
    }   
}
