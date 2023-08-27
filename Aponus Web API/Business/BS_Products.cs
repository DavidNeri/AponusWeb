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
using System.Reflection;
using MessagePack;
using System;

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

        internal void GuardarProducto(DTOProducto producto)
        {
            OperacionesProductos operacionesProductos = new OperacionesProductos();

           // try
           // {
                producto.Producto.IdProducto= operacionesProductos.GenerarIdProd(producto); //Coorejir

               // operacionesProductos.DTOProducto(producto);
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

            return new ComponentesProductos().ObtenerComponentesFormateados(Producto);
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

        internal void NuevoGuardarProducto(DTOProducto producto)
        {
            OperacionesProductos operacionesProductos = new OperacionesProductos();
            string IdProducto = operacionesProductos.GenerarIdProd(producto);

            producto.Producto.IdProducto = IdProducto;

            producto.Componentes.All(x => { x.IdProducto = IdProducto; return true; });

            operacionesProductos.GuardarProducto(producto);

            operacionesProductos.GuardarComponentes(producto.Componentes);


        }

        internal IActionResult Actualizar(DTOProducto _Producto)
        {
            OperacionesProductos OP= new OperacionesProductos();
            bool UpdateIdProd = false;
            if (_Producto.Producto.IdProducto != null)
            {
                try
                {
                    PropertyInfo[]? DetallesProductoProps = _Producto.Producto.DetallesProducto.GetType().GetProperties();
                    DetallesProductoProps = DetallesProductoProps.Where(prop=>prop.GetValue(_Producto.Producto.DetallesProducto)!=null).ToArray();
                    //string? IdProducto = DetallesProductoProps.FirstOrDefault(prop=>prop.Name.Contains("IdProducto")).GetValue(_Producto.Producto.DetallesProducto).ToString();

                    Producto? ProductUpdateDetails = OP.BuscarProducto(_Producto.Producto.IdProducto);

                    foreach (PropertyInfo prop in DetallesProductoProps)
                    {

                        //string? ValorActual = prop.GetValue(_Producto.Producto.DetallesProducto).ToString();

                        var ValorActual = prop.GetValue(_Producto.Producto.DetallesProducto);

                        if (ValorActual != null) //ValorActual!=null
                        {

                            string Propiedad = prop.Name;

                            var _valorOriginal = ProductUpdateDetails.GetType().GetProperty(prop.Name).GetValue(ProductUpdateDetails);

                            //string ValorOriginal = OP.ObtenerValor(Propiedad, IdProducto);
                               
                            if (((_valorOriginal.GetType() == ValorActual.GetType() && !_valorOriginal.Equals(ValorActual)) && 
                                !prop.Name.Contains("Cantidad") && 
                                //ValorActual.ToString()!= "-1" && 
                                _valorOriginal!=null))
                            {
                                int resultado;

                                //(Int32.TryParse((string?)ValorActual, out resultado)

                                if (ValorActual.ToString()== "-1")
                                {
                                    prop.SetValue(null, null);
                                }
                              

                                OP.Actualizar(prop, _Producto.Producto.DetallesProducto, ProductUpdateDetails);


                                if (!prop.Name.Equals("Cantidad") ||
                                    !prop.Name.Equals("Precio") ||
                                    !prop.Name.Equals("idProducto"))
                                {
                                    UpdateIdProd= true;
                                }

                            }
                        }         
                                                
                    }

                    if (ProductUpdateDetails != null)
                    {
                        OP.ModifyProductDetails(ProductUpdateDetails);

                    }


                    if (_Producto.Componentes!=null)
                    {
                        //ComponentesProductos Componentes= new ComponentesProductos();
                        List<DTOComponentesProducto> ProducComponentsUpdate = new ComponentesProductos().ObtenerComponentes(_Producto.Producto.IdProducto);

                        foreach (DTOComponentesProducto Componente in _Producto.Componentes)
                        {
                            if (Componente.Cantidad==-1)
                            {
                                if (Componente.IdProducto==null)
                                {
                                    Componente.IdProducto = _Producto.Producto.IdProducto;
                                }


                                OP.EliminarComponente(new Productos_Componentes()
                                {
                                    IdComponente=Componente.IdComponente,
                                    IdProducto=Componente.IdProducto,
                                });;

                                ProducComponentsUpdate.Remove(Componente);
                            }
                            else
                            {
                                int indice = ProducComponentsUpdate.FindIndex(x => x.IdComponente.Contains(Componente.IdComponente));
                                if (indice != null)
                                {
                                    ProducComponentsUpdate[indice] = Componente;


                                }
                                else
                                {
                                    OP.AgregarComponente(new Productos_Componentes()
                                    {
                                        IdComponente = Componente.IdComponente,
                                        IdProducto = Componente.IdProducto,
                                    });
                                    ProducComponentsUpdate.Remove(Componente);

                                }

                               
                            }


                            if (ProducComponentsUpdate!=null)
                            {
                                List<Productos_Componentes> ListComponentesUpdate = new List<Productos_Componentes>();

                                foreach (DTOComponentesProducto Componete in ProducComponentsUpdate)
                                {
                                    ListComponentesUpdate.Add(new Productos_Componentes()
                                    {
                                        Cantidad = Componete.Cantidad,
                                        IdComponente = Componete.IdComponente,
                                        IdProducto = Componete.IdProducto,
                                        Peso = Componete.Peso,
                                        Longitud = Componete.Largo

                                    });
                                }

                                OP.ModifyProductComponents(ListComponentesUpdate);

                            }


                        }

                        

                    }




                    return new StatusCodeResult(200);
                }
                catch (Exception)
                {

                    return null;
                }

                //para la unidad de medidda "GetUnidadComponente" o "ObtenerUnidadComponente"




            }
            else
                return new ContentResult()
                {
                    Content = "El _Producto no puede estar vacio",
                    ContentType = "tex/plain"
                };
        }
    }   
}
