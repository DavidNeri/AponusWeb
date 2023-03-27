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

        internal IActionResult GuardarProducto(DatosProducto producto, List<ComponentesProducto> Componentes)
        {
            
            TablaInsumo _ObtenerTabla = new TablaInsumo();

            try
            {
                foreach (ComponentesProducto Componente in Componentes)
                { 

                    switch (_ObtenerTabla.ObtenerTabla(new Insumos { IdInsumo = Componente.IdComponente }))
                    {
                        case 0:

                            break;
                        case 1:
                            break;

                        case 2:
                            break;
                        default:
                            break;
                    }

                }

                

            }
            catch (Exception)
            {

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

           
           
            return null;

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
