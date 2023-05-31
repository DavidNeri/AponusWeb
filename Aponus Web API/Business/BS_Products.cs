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
using Aponus_Web_API.Acceso_a_Datos.Componentes;

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
            foreach (DTOComponentesProducto Componente in producto.Componentes)
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

            

        }

        internal  async Task<JsonResult> ListarDN(string? typeId)
        {
             return await new  ObtenerProductos().ListarDN(typeId);
        }

        internal async Task<JsonResult> ListarDN(string? typeId, int? idDescription)
        {
            return await new ObtenerProductos().ListarDN(typeId, idDescription);
        }

        internal JsonResult NewListarComponentesProducto(DTODetallesProducto Producto)
        {

            Producto.Cantidad ??= 1;

            return new ComponentesProductos().ObtenerComponentesProducto(Producto);
        }

        internal Task<JsonResult> ListarProductos(string? TypeId) {

            return new ObtenerProductos().Listar(TypeId);

        }

        internal JsonResult ListarProductos()
        {
            return new ObtenerProductos().Listar();
        }

        internal Task<JsonResult> ListarProductos(string? typeId, int? IdDescription)
        {
            return new ObtenerProductos().Listar(typeId, IdDescription);
        }

        internal Task<JsonResult> ListarProductos(string? typeId, int? IdDescription, int? Dn)
        {

            return new ObtenerProductos().Listar(typeId, IdDescription, Dn);

        }

        internal void NuevoGuardarProducto(GuardarProducto producto)
        {
            OperacionesProductos operacionesProductos = new OperacionesProductos();
            string IdProducto = operacionesProductos.GenerarIdProd(producto);

            producto.Producto.IdProducto = IdProducto;

            producto.Componentes.All(x => { x.IdProducto = IdProducto; return true; });

            operacionesProductos.GuardarProducto(producto);

            operacionesProductos.GuardarComponentes(producto.Componentes);


        }
    }   
}
