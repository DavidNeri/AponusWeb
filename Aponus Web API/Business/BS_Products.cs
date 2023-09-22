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
using System.Data.Common;

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
                producto.Producto.IdProducto= operacionesProductos.GenerarIdProd(producto.Producto.DetallesProducto); //Coorejir

               // OP.DTOProducto(ProductUpdate);
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

        internal IActionResult NuevoGuardarProducto(DTODetallesProducto ActualizarProducto)
        {
            OperacionesProductos OP = new OperacionesProductos();
          

            if (ActualizarProducto.IdProducto== null
                && ActualizarProducto.IdTipo!=null
                && ActualizarProducto.IdDescripcion!=null
                && ActualizarProducto.DiametroNominal!=null
                && ActualizarProducto.Tolerancia!=null)
            {
                //Producto Nuevo
                ActualizarProducto.IdProducto = OP.GenerarIdProd(ActualizarProducto);
                Producto? _BuscarProducto = OP.BuscarProducto(ActualizarProducto.IdProducto);

                //Si no encontro el Producto despues de generar el ID, guarda el nuevo
                if (_BuscarProducto == null) 
                    OP.GuardarProducto(ActualizarProducto);

                //Si lo encontro despues de haber generado el ID es un actualizar 
                if (_BuscarProducto != null) 
                    ProductUpdate(ActualizarProducto);

                return new JsonResult(ActualizarProducto.IdProducto);

            }
            else if (ActualizarProducto.IdProducto == null
                && (ActualizarProducto.IdTipo != null
                || ActualizarProducto.IdDescripcion != null
                || ActualizarProducto.DiametroNominal != null
                || ActualizarProducto.Tolerancia != null))
            {
                //Si No pasaron el IdProducto (Nuevo) pero falta algun campo necesario para generar el Nuevo Id
                return new ContentResult()
                {
                    Content = "Faltan Datos",
                    ContentType = "application/json",
                    StatusCode = 400,

                };
            }
            else if (ActualizarProducto.IdProducto != null)
            {
                //Si pasaron el IdProducto
               
                return ProductUpdate(ActualizarProducto);
                
            }
            else
            {
                return new ContentResult()
                {
                    Content = "Faltan Datos, No se realizaron modificaciones",
                    ContentType = "application/json",
                    StatusCode=400,

                };
            }

        }

        internal IActionResult ProductUpdate(DTODetallesProducto ActualizarProducto)
        {
            OperacionesProductos OP = new OperacionesProductos();
            bool UpdateIdProd = false;
            try
            {
                Producto? ProductoOriginal = OP.BuscarProducto(ActualizarProducto.IdProducto);
                PropertyInfo[]? PropsActualizarProducto = ActualizarProducto
                    .GetType()
                    .GetProperties()
                    .Where(prop => prop.GetValue(ActualizarProducto) != null)
                    .ToArray();

                if (ProductoOriginal != null)
                {
                    foreach (PropertyInfo prop in PropsActualizarProducto)
                    {
                        //Modificar atributos del producto existente
                        PropertyInfo? _valorOriginal = ProductoOriginal.GetType().GetProperty(prop.Name);
                        var valorOriginal = _valorOriginal.GetValue(ProductoOriginal);
                        var valorNuevo = prop.GetValue(ActualizarProducto);

                        if (!valorOriginal.Equals(valorNuevo) && prop.Name != "idProducto")
                        {
                            _valorOriginal.SetValue(ProductoOriginal, valorNuevo);
                            if (prop.Name.Contains("IdDescripcion") || prop.Name.Contains("Tolerancia") || prop.Name.Contains("IdTipo"))
                            {
                                if (valorNuevo == null)
                                {
                                    //Si alguno de los campos necesarios para generar el Nuevo ID es Nulo
                                    return new ContentResult()
                                    {
                                        Content = "Faltan Datos, No se realizaron modificaciones",
                                        ContentType = "application/json",
                                        StatusCode = 400,

                                    };
                                }
                                else
                                {
                                    UpdateIdProd = true;
                                }
                                
                            }

                        }
                    }
                    //Asignar nuevo Nombre  al objeto 'ProductoOriginal'
                    Producto ProductoOriginalModificado = ProductoOriginal;
                   

                    //En caso de corresponder actualizar el IDProducto
                    if (UpdateIdProd == true)
                    {
                        string IdAnterior = ActualizarProducto.IdProducto;

                        string NuevoId = OP.GenerarIdProd(new DTODetallesProducto()
                        {
                            IdProducto = null,
                            DiametroNominal = ProductoOriginalModificado.DiametroNominal,
                            IdDescripcion = ProductoOriginalModificado.IdDescripcion,
                            IdTipo = ProductoOriginalModificado.IdTipo,
                            Tolerancia = ProductoOriginalModificado.Tolerancia

                        });

                        if (IdAnterior != NuevoId)
                        {
                            if (OP.BuscarProducto(NuevoId) != null)
                            {
                                return new ContentResult()
                                {
                                    Content = "Producto existente, no se aplicaron los cambios",
                                    ContentType = "application/json",
                                    StatusCode = 400,

                                };
                            }

                            OP.ModifyProductDetails(ProductoOriginalModificado);
                            OP.ActualizarIdProd(IdAnterior, NuevoId);
                            
                            return new JsonResult(NuevoId);
                        }

                    }
                    else
                    {
                        if (ProductoOriginalModificado != null)  OP.ModifyProductDetails(ProductoOriginalModificado);
                    }

                    return new JsonResult(ProductoOriginalModificado.IdProducto);
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = "No se encontró el Producto a Modificar",
                        ContentType = "application/json",
                        StatusCode = 404,

                    };
                }

            }
            catch (Exception ex)
            {

                return new ContentResult()
                {
                    Content = "Producto existente, no se aplicaron los cambios",
                    ContentType = "application/json",
                    StatusCode = 400    ,

                };
            }
        }

        internal IActionResult ActualizarComponentes(List<DTOComponentesProducto> Componentes)
        {
            OperacionesProductos OP = new OperacionesProductos();
            List<Productos_Componentes> ListaComponentes = new List<Productos_Componentes>();
            ComponentesProductos CP = new ComponentesProductos();

            try
            {
                OP.DeleteAllProductComponents(Componentes
                        .Where(x => x.IdProducto != null)
                        .Select(x => x.IdProducto)
                        .First()
                        .ToString());

                foreach (DTOComponentesProducto componente in Componentes)
                {
                    ListaComponentes.Add(new Productos_Componentes()
                    {
                        Cantidad = componente.Cantidad,
                        IdComponente = componente.IdComponente,
                        IdProducto = componente.IdProducto,
                        Longitud = componente.Largo,
                        Peso = componente.Peso,

                    });
                }                
                   

                foreach (Productos_Componentes Componente in ListaComponentes)
                {
                    CP.GuardarComponenteProd(Componente);

                }

                return new StatusCodeResult(200);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException.Message!=null)
                {
                    return new ContentResult()
                    {
                        Content= ex.InnerException.Message, 
                        ContentType= "application/json",
                    };
                }
                else
                {

                    return new ContentResult()
                    {
                        Content = ex.Message,
                        ContentType = "application/json",
                    };
                }
            }catch(Exception ex)
            {
                if (ex.InnerException.Message != null)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException.Message,
                        ContentType = "application/json",
                    };
                }
                else
                {

                    return new ContentResult()
                    {
                        Content = ex.Message,
                        ContentType = "application/json",
                    };
                }
            }
           
                
        }

        


    }
}
