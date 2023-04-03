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

        internal IActionResult GuardarProducto(GuardarProducto producto)
        {
            OperacionesProductos operacionesProductos = new OperacionesProductos();

            try
            {
                operacionesProductos.GuardarProducto(producto.Producto);

                foreach (ComponentesProducto Componente in producto.Componentes)
                { 

                    switch (new TablaInsumo().ObtenerTabla(new Insumos { IdInsumo = Componente.IdComponente }))
                    {
                        case 0:
                            operacionesProductos.GuardarComponententesPesables(producto.Producto,Componente);
                            break;
                        case 1:
                            operacionesProductos.GuardarComponententesCuantitativos(producto.Producto, Componente);
                            break;

                        case 2:
                            operacionesProductos.GuardarComponententesMensurables(producto.Producto, Componente);
                            break;
                        default:
                            break;
                    }


                }

                

            }
            catch (Exception)
            {
               // operacionesProductos.EliminarComponententesPesables(producto, Componentes);
               // operacionesProductos.EliminarComponententesCuantitativos(producto, Componentes);
                //operacionesProductos.EliminarComponententesMensurables(producto, Componentes);
                //operacionesProductos.EliminarProducto(producto);


                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }



            return new StatusCodeResult(StatusCodes.Status200OK);

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
