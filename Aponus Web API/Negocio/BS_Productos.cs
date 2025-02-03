using Aponus_Web_API.Acceso_a_Datos;
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
            return new JsonResult(AdProductos.Listar());
        }
        internal JsonResult ListarProductos(string? typeId, int? IdDescription)
        {
            return AdProductos.Listar(typeId, IdDescription);


        }
        //internal JsonResult ListarProductos(string? typeId, int? IdDescription, int? Dn)
        //{

        //    return AdProductos.Listar(typeId, IdDescription, Dn);

        //}
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
                ActualizarProducto(Producto);

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

        internal IActionResult ActualizarProducto(DTOProducto producto)
        {
            try
            {  
                Producto _producto = new()
                {
                    IdProducto = producto.IdProducto ?? "",
                    IdDescripcion = producto.IdDescripcion ?? 0,
                    IdTipo = producto.IdTipo ?? "",
                    DiametroNominal = producto.DiametroNominal,
                    Cantidad = 0,
                    PrecioLista = producto.PrecioLista ?? 0,
                    Tolerancia = producto.Tolerancia,
                    IdEstado = 1,                    
                    PrecioFinal = producto.PrecioFinal,
                    PorcentajeGanancia = producto.PorcentajeGanancia ?? producto.PrecioFinal ?? 0 - producto.PrecioLista ?? 0
                };

                AdProductos.HabilitarProducto(_producto);

                return new JsonResult(producto.IdProducto);

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

        internal async Task<object> ObtenerProductosFaltantes()
        {
            List<ProductosDescripcion> Productos =  AdProductos.Listar() 
                as List<ProductosDescripcion> ?? new List<ProductosDescripcion>();          

            return(Productos
                .Select(x => x.Productos.Where(x => x.Cantidad <= 100).ToList())
                .ToList());

        }
    }
}
