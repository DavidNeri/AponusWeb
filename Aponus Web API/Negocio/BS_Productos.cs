﻿using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Aponus_Web_API.Negocio
{
    public class BS_Productos
    {
        private readonly AD_Componentes _componentesProductos;
        private readonly AD_Productos AdProductos;
        public BS_Productos(AD_Componentes componentesProductos, AD_Productos adProductos)
        {
            _componentesProductos = componentesProductos;
            AdProductos = adProductos;
        }

        internal async Task<JsonResult> ListarDN(string? typeId)
        {
            return await AdProductos.ListarDN(typeId ?? "");
        }
        internal async Task<JsonResult> ListarDN(string? typeId, int? idDescription)
        {
            return await AdProductos.ListarDN(typeId, idDescription);
        }
        internal JsonResult NewListarComponentesProducto(DTOProducto Producto)
        {

            Producto.Cantidad ??= 1;

            return _componentesProductos.ObtenerComponentesFormateados(Producto);
        }
        internal JsonResult ListarProductos(string? TypeId)
        {

            return AdProductos.Listar(TypeId ?? "");

        }
        internal JsonResult ListarProductos()
        {
            return AdProductos.Listar();
        }
        internal JsonResult ListarProductos(string? typeId, int? IdDescription)
        {
            return AdProductos.Listar(typeId, IdDescription);
        }
        internal JsonResult ListarProductos(string? typeId, int? IdDescription, int? Dn)
        {

            return AdProductos.Listar(typeId, IdDescription, Dn);

        }
        internal IActionResult ProcesarDatos(DTOProducto Producto)
        {

            if (Producto.IdProducto == null)
            {
                if (Producto.IdTipo != null && Producto.IdDescripcion != null && Producto.DiametroNominal != null && Producto.Tolerancia != null)
                {

                    Producto.IdProducto = GenerarIdProd(Producto); //Producto NuevoAcceso
                    Producto? _BuscarProducto = AdProductos.BuscarProducto(Producto.IdProducto);


                    if (_BuscarProducto == null) //Si no encontro el Producto despues de generar el ID, guarda el nuevo
                    {
                        AdProductos.GuardarProducto(Producto);
                    }
                    else
                    {
                        ActualizarProducto(Producto);
                    }

                    if (Producto.Componentes != null)
                    {
                        foreach (var Componente in Producto.Componentes)
                        {
                            Componente.IdProducto = Producto.IdProducto;
                        }

                        ActualizarComponentes(Producto.Componentes);
                    }

                    return new JsonResult(Producto.IdProducto);
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = "Faltan Datos",
                        ContentType = "application/json",
                        StatusCode = 400,
                    };
                }
            }
            else
            {
                return ActualizarProducto(Producto);
            }
        }

        public string GenerarIdProd(DTOProducto Producto)
        {
            string IdProducto;

            try
            {
                string Tolerancia = Producto.Tolerancia ?? "".Replace("-", "_").Replace("/", "_");
                IdProducto = $"{Producto.IdTipo}_{Producto.IdDescripcion}_{Producto.DiametroNominal}_{Producto.Tolerancia}";

            }
            catch (Exception)
            {

                return "";
            }

            return IdProducto;
        }

        internal IActionResult ActualizarProducto(DTOProducto ActualizarProducto)
        {
            bool UpdateIdProd = false;

            try
            {
                Producto? ProductoOriginal = AdProductos.BuscarProducto(ActualizarProducto.IdProducto ?? "");
                PropertyInfo[]? PropsActualizarProducto = ActualizarProducto.GetType().GetProperties().Where(prop => prop.GetValue(ActualizarProducto) != null).ToArray();

                if (ProductoOriginal != null)
                {
                    ProductoOriginal.IdEstado = 1;

                    foreach (PropertyInfo prop in PropsActualizarProducto)
                    {
                        //Modificar atributos del p existente
                        PropertyInfo? _valorOriginal = ProductoOriginal.GetType().GetProperty(prop.Name);

                        if (_valorOriginal != null)
                        {
                            var valorOriginal = _valorOriginal.GetValue(ProductoOriginal);
                            var valorNuevo = prop.GetValue(ActualizarProducto);

                            if (valorOriginal != null && !valorOriginal.Equals(valorNuevo) && prop.Name != "idProducto")
                            {
                                _valorOriginal.SetValue(ProductoOriginal, valorNuevo);
                                if (prop.Name.Contains("IdDescripcion") || prop.Name.Contains("Tolerancia") || prop.Name.Contains("IdTipo"))
                                {
                                    if (valorNuevo == null)
                                    {
                                        //Si alguno de los campos necesarios para generar el NuevoAcceso ID es Nulo
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
                    }

                    //Asignar nuevo Nombre  al objeto 'ProductoOriginal'
                    Producto ProductoModificado = ProductoOriginal;


                    //En caso de corresponder actualizar el IDProducto
                    if (UpdateIdProd == true)
                    {
                        string IdAnterior = ActualizarProducto.IdProducto ?? "";

                        string NuevoId = GenerarIdProd(new DTOProducto()
                        {
                            IdProducto = null,
                            DiametroNominal = ProductoModificado.DiametroNominal,
                            IdDescripcion = ProductoModificado.IdDescripcion,
                            IdTipo = ProductoModificado.IdTipo,
                            Tolerancia = ProductoModificado.Tolerancia
                        });

                        if (IdAnterior != NuevoId)
                        {
                            if (AdProductos.BuscarProducto(NuevoId) != null)
                            {
                                return new ContentResult()
                                {
                                    Content = "Producto existente, no se aplicaron los cambios",
                                    ContentType = "application/json",
                                    StatusCode = 400,

                                };
                            }

                            AdProductos.ActualizarDetallesProducto(ProductoModificado);
                            AdProductos.ActualizarIdProd(IdAnterior, NuevoId);

                            return new JsonResult(NuevoId);
                        }

                    }
                    else
                    {
                        if (ProductoModificado != null) AdProductos.ActualizarDetallesProducto(ProductoModificado);
                    }

                    return new JsonResult(ProductoModificado?.IdProducto ?? null);
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
            catch (Exception)
            {
                return new ContentResult()
                {
                    Content = "Producto existente, no se aplicaron los cambios",
                    ContentType = "application/json",
                    StatusCode = 400,

                };
            }
        }
        internal IActionResult ActualizarComponentes(List<DTOComponentesProducto> Componentes)
        {
            List<Productos_Componentes> ListaComponentes = new List<Productos_Componentes>();

            try
            {
                if (Componentes != null)
                {
                    string IdProducto = Componentes.Where(x => x.IdProducto != null).Select(x => x.IdProducto).FirstOrDefault() ?? "";
                    AdProductos.EliminarComponentesProducto(IdProducto);
                }

                foreach (DTOComponentesProducto componente in Componentes ?? Enumerable.Empty<DTOComponentesProducto>())
                {
                    ListaComponentes.Add(new Productos_Componentes()
                    {
                        Cantidad = componente.Cantidad,
                        IdComponente = componente.IdComponente ?? "",
                        IdProducto = componente.IdProducto ?? "",
                        Longitud = componente.Largo,
                        Peso = componente.Peso                    
                    });
                }

                foreach (Productos_Componentes Componente in ListaComponentes)
                {
                    _componentesProductos.GuardarComponenteProd(Componente);
                }
                return new StatusCodeResult(200);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message != null)
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
            catch (Exception ex)
            {
                if (ex.InnerException?.Message != null)
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

        internal JsonResult MapeoDTOProducto(string idProducto)
        {
            DTOProducto Prod = new();
            Producto? p = AdProductos.BuscarProducto(idProducto);            

            if (p != null)
            {
                Prod.DiametroNominal = p.DiametroNominal;
                Prod.Cantidad = p.Cantidad;
                Prod.IdDescripcion = p.IdDescripcion;
                Prod.IdTipo = p.IdTipo;
                Prod.IdProducto = p.IdProducto;
                Prod.PorcentajeGanancia = p.PorcentajeGanancia;
                Prod.PrecioFinal = p.PrecioFinal;
                Prod.PrecioLista = p.PrecioLista;
                Prod.Tolerancia = p.Tolerancia;                
            }

            return new JsonResult(Prod);
        }
    }
}
