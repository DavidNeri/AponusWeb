using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using System.Text.RegularExpressions;
using ArchivosVentas = Aponus_Web_API.Modelos.ArchivosVentas;

namespace Aponus_Web_API.Negocio
{
    public class BS_Ventas
    {
        private readonly AD_Ventas AdVentas;
        private readonly AD_Entidades AdEntidades;
        private readonly AD_Productos AdProductos;

        public BS_Ventas(AD_Ventas adVentas, AD_Entidades adEntidades, AD_Productos adProductos)
        {
            AdVentas = adVentas;
            AdEntidades = adEntidades;
            AdProductos = adProductos;
        }

        public Estados EstadosVentas()
        {
            return new Estados(AdVentas);
        }
        public class Estados
        {
            private readonly AD_Ventas AdVentas;

            public Estados(AD_Ventas adVentas)
            {
                AdVentas = adVentas;
            }
            internal IActionResult Eliminar(int id)
            {
                try
                {
                    AdVentas.EliminarEstado(new EstadosVentas()
                    {
                        IdEstadoVenta = id
                    });
                    return new StatusCodeResult(200);
                }
                catch (Exception ex)
                {

                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        ContentType = "application/json",
                        StatusCode = 100
                    };
                }
            }
            internal async Task<IActionResult> ValidarDatos(DTOEstadosVentas Estado)
            {
                try
                {

                    Estado.Descripcion = Regex.Replace(Estado.Descripcion ?? "", @"\s+", " ").Trim().ToUpper();

                    if (string.IsNullOrEmpty(Estado.Descripcion))
                        return new ContentResult()
                        {
                            Content = "El estado no puede estar vacío",
                            ContentType = "application/json",
                            StatusCode = 400
                        };

                    await AdVentas.GuardarEstado(Estado);
                    return new StatusCodeResult(200);

                }
                catch (Exception ex)
                {

                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        ContentType = "application/json",
                        StatusCode = 400

                    };
                }
            }
        }
        internal async Task<IActionResult> ProcesarDatosVenta(DTOVentas Venta)
        {
            decimal saldoPendiente = Venta.MontoTotal;

            if (Venta.DetallesVenta == null || (Venta.Cuotas == null && Venta.Pagos == null))
            {
                return new ContentResult()
                {
                    Content = "Faltan Datos",
                    ContentType = "application/json",
                    StatusCode = 400,
                };
            }
            else
            {
                Ventas NuevaVenta = new()
                {
                    IdCliente = Venta.IdCliente,                    
                    IdUsuario = Venta.IdUsuario,
                    FechaHora = UTL_Fechas.ObtenerFechaHora(),
                    Cliente = new Entidades { IdEntidad = Venta.IdCliente },
                    Usuario = new Usuarios { Usuario = Venta.IdUsuario },
                    MontoTotal = Venta.MontoTotal,
                    SaldoPendiente = Venta.SaldoPendiente ?? 0,
                    IdEstadoVenta = 1,

                    DetallesVenta = Venta.DetallesVenta.Select(vta => new VentasDetalles()
                    {
                        IdProducto = vta.IdProducto,
                        Cantidad = vta.Cantidad,
                        Precio = vta.Precio,
                        IdProductoNavigation = new Producto { IdProducto = vta.IdProducto },
                        Entregados = vta.Entregados ?? 0,

                    }).ToList(),
                };


                if (Venta.Pagos != null)
                {
                    foreach (var vtaPagos in Venta.Pagos)
                    {
                        saldoPendiente = saldoPendiente - vtaPagos.Monto;

                        NuevaVenta.Pagos.Add(new PagosVentas()
                        {
                            Fecha = vtaPagos.Fecha ?? UTL_Fechas.ObtenerFechaHora(),
                            Monto = vtaPagos.Monto,
                            IdMedioPago = vtaPagos.IdMedioPago,
                            IdEntidadPago = vtaPagos.IdEntidadPago
                        });
                    }

                    NuevaVenta.SaldoPendiente = NuevaVenta.SaldoPendiente ?? saldoPendiente;
                }
                if (Venta.Cuotas != null || Venta?.Cuotas?.Count > 0)
                {
                    List<CuotasVentas> cuotasVenta = new List<CuotasVentas>();
                    var CuotasVenta = Venta.Cuotas;

                    foreach (var Cuota in CuotasVenta)
                    {
                        cuotasVenta.Add(new CuotasVentas()
                        {
                            IdCuota = Cuota.IdCuota ?? 0,
                            FechaVencimiento = Cuota.FechaVencimiento,
                            IdEntidad = Cuota.IdEntidad ?? 0,
                            FechaPago = Cuota.FechaPago,
                            IdEstadoCuota = Cuota.FechaPago != null ? 1 : 2,
                            NumeroCuota = Cuota.NumeroCuota,
                            Monto = Cuota.Monto,
                            Pagos = Cuota.Pagos.Select(x => new PagosVentas()
                            {
                                IdCuota = x.IdCuota ?? 0,
                                IdMedioPago = x.IdMedioPago,
                                Monto = x.Monto,
                                Fecha = x.Fecha,
                                IdEntidadPago = x.IdEntidadPago,
                                Venta = null,

                            }).ToList(),
                        });
                    }

                    NuevaVenta.Cuotas = cuotasVenta;
                }

                if (Venta?.IdVenta != null && Venta.IdVenta.HasValue)
                {
                    int _IdVenta = Venta.IdVenta.Value;
                    Ventas? _Venta = await AdVentas.BuscarVenta(_IdVenta);

                    if (_Venta != null)
                    {
                        Venta.IdVenta = _IdVenta;
                    }
                }


                int? IdVenta = await AdVentas.Guardar(NuevaVenta);

                if (Venta?.Archivos != null && Venta.Archivos.Count>0)
                {
                    IQueryable<Entidades> Entidades = AdEntidades.ListarEntidades();
                    var DatosCliente = Entidades.SingleOrDefault(x => x.IdEntidad == Venta.IdCliente);
                    string Cliente = string.IsNullOrEmpty(DatosCliente?.NombreClave) ?
                        $"{DatosCliente?.Apellido}_{DatosCliente?.Nombre}" :
                        DatosCliente.NombreClave;

                    List<(string Hash, string Path)> DatosUpload = new UTL_Cloudinary().SubirArchivosCloudinary(Venta.Archivos, Cliente);

                    List<ArchivosVentas> archivosVentas = new();

                    foreach (var Dato in DatosUpload)
                    {
                        archivosVentas.Add(new ArchivosVentas()
                        {
                            HashArchivo = Dato.Hash,
                            IdEstado = 1,
                            IdVenta = IdVenta ?? 0,
                            PathArchivo = Dato.Path,
                        });
                    }

                    var (Resultado, error) = await AdVentas.GuardarArchivos(archivosVentas);

                    if (error != null)
                    {
                        return new ContentResult()
                        {
                            Content = error.InnerException?.Message ?? error.Message,
                            ContentType = "application/json",
                            StatusCode = 400
                        };
                    }

                }

                if (IdVenta != null)
                    return new StatusCodeResult(200);
                else
                    return new ContentResult()
                    {
                        Content = "Error interno, no se aplicaron los cambios",
                        ContentType = "application/json",
                        StatusCode = 400
                    };
            }
        }
        public static ICollection<DTOCuotasVentas> CalcularCuotas(UTL_ParametrosCuotas Parametros)
        {
            ICollection<DTOCuotasVentas> NvaVtaCuotas = new List<DTOCuotasVentas>();
            DateTime Vencimiento = UTL_Fechas.ObtenerFechaHora();

            decimal MontoCuota = Parametros.MontoVenta / Parametros.CantidadCuotas + (Parametros.MontoVenta * Parametros.Interes / Parametros.CantidadCuotas);
            decimal Resto = Parametros.MontoVenta % Parametros.CantidadCuotas;

            for (int i = 1; i <= Parametros.CantidadCuotas; i++)
            {
                Vencimiento = i switch
                {
                    1 => Vencimiento,
                    _ => Vencimiento.AddDays(30)
                };

                NvaVtaCuotas.Add(new DTOCuotasVentas()
                {
                    NumeroCuota = i,

                    Monto = i switch
                    {
                        int n when n == Parametros.CantidadCuotas => MontoCuota + Resto,
                        _ => MontoCuota,
                    },

                    FechaVencimiento = Vencimiento,
                    IdEntidad = Parametros.IdEntidad,
                    IdEstadoCuota = 1


                });
            }


            return NvaVtaCuotas;
        }
        internal IActionResult Filtrar(UTL_FiltrosComprasVentas? filtros)
        {
            try
            {
                IQueryable<Ventas> QueryVentas = AdVentas.ListarVentas();

                if (filtros?.IdEntidad != null)
                    QueryVentas = QueryVentas.Where(x => x.IdCliente == filtros.IdEntidad);
                if (filtros?.Desde != null)
                    QueryVentas = QueryVentas.Where(X => X.FechaHora >= filtros.Desde);
                if (filtros?.Hasta != null)
                    QueryVentas = QueryVentas.Where(X => X.FechaHora >= filtros.Hasta);


                List <DTOVentas> ListadoVentas = QueryVentas.Select(x => new DTOVentas()
                {
                    IdVenta = x.IdVenta,
                    IdCliente = x.IdCliente,
                    FechaHora = x.FechaHora,
                    IdUsuario = x.IdUsuario,
                    IdEstadoVenta = x.IdEstadoVenta,
                    MontoTotal = x.MontoTotal,
                    SaldoPendiente = x.SaldoPendiente,
                    DetallesVenta = x.DetallesVenta.Select(y => new DTOVentasDetalles()
                    {
                        
                        Cantidad = y.Cantidad,
                        IdProducto = y.IdProducto,
                        IdVenta = y.IdVenta,
                        Precio = y.Precio
                    })
                    .ToList(),
                    Cuotas = x.Cuotas.Select(Cuotas => new DTOCuotasVentas()
                    {
                        FechaPago = Cuotas.FechaPago,
                        FechaVencimiento = Cuotas.FechaVencimiento,
                        NumeroCuota = Cuotas.NumeroCuota,
                        IdEntidad = Cuotas.IdEntidad,
                        Monto = Cuotas.Monto,
                        IdCuota = Cuotas.IdCuota,
                        IdVenta = Cuotas.IdVenta,   
                        EstadoCuota = new DTOEstadosCuotasVentas()
                        {
                            Descripcion = Cuotas.EstadoCuota.Descripcion,
                            IdEstado = Cuotas.EstadoCuota.IdEstado,
                        }
                    })
                    .ToList(),

                    Cliente = new DTOEntidades()
                    {
                        Nombre = x.Cliente.Nombre,
                        Apellido = x.Cliente.Apellido,
                        NombreClave = x.Cliente.NombreClave,
                        IdTipo = x.Cliente.IdTipo,
                        IdCategoria = x.Cliente.IdCategoria,
                    },

                    Pagos = x.Pagos.Select(Pagos => new DTOPagosVentas()
                    {
                        IdMedioPago = Pagos.IdMedioPago,
                        IdPago = Pagos.IdPago,                        
                        IdVenta = Pagos.IdVenta,
                        Monto = Pagos.Monto,
                        MedioPago = new DTOMediosPago()
                        {
                            Descripcion = Pagos.MedioPago.Descripcion,
                            IdMedioPago = Pagos.MedioPago.IdMedioPago,
                            CodigoMPago = Pagos.MedioPago.CodigoMPago,
                        }

                    }).ToList(),

                    infoArchivos = x.Archivos
                                        .Where(x => x.IdEstado != 0)
                                        .Select(y => new DTOArchivosVentas()
                                        {
                                            HashArchivo = y.HashArchivo,
                                            IdArchivo = y.IdArchivo,
                                            IdVenta = y.IdVenta,
                                            PathArchivo = y.PathArchivo,
                                            MimeType = y.MimeType,
                                            IdEstado = y.IdEstado
                                        }).ToList(),

                    Estado = new DTOEstadosVentas()
                    {
                        Descripcion = x.Estado.Descripcion,
                        IdEstado = x.Estado.IdEstadoVenta,
                    }

                }).ToList();

                var IdProdTodasVentas = ListadoVentas.Select(x => x.DetallesVenta?.Select(y=>y.IdProducto).ToList()).ToList();
                List<string> ProductosId = new List<string>();

                foreach (var venta in IdProdTodasVentas)
                {
                    var i = 0;

                    while (i < venta?.Count)
                    {
                        var IdVenta = venta[i];

                        ProductosId.Add(IdVenta);
                        i++;
                    }                    
                }

                List<DTOProducto> NombresProductosVenta = AdProductos.ListarProdVentas(ProductosId);

                ListadoVentas.ForEach(venta =>
                {
                    foreach (var Producto in venta.DetallesVenta ?? Enumerable.Empty<DTOVentasDetalles>())
                    {
                         Producto.NombreProducto = NombresProductosVenta?
                        .Where(x => x.IdProducto == Producto.IdProducto)
                        .Select(x => x.Nombre)
                        .FirstOrDefault() ?? "";
                    }
                });


                return new JsonResult(ListadoVentas);
            }
            catch (Exception ex)
            {

                return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }
        }

        internal async Task<IActionResult> MapeoDTOPagosVenta(DTOPagosVentas Pago)
        {

            var ex = await AdVentas.RegistrarPagoCuota(Pago.IdVenta,Pago.IdCuota ?? 0);

            if (ex != null) return new ContentResult()
            {
                Content = ex.InnerException?.Message ?? ex.Message,
                ContentType = "application/json",
                StatusCode = 400
            };

            return new StatusCodeResult(200);
        }

        internal async Task<IActionResult> ProcesarArchivos(DTOVentas ArchivosVenta)
        {
            IQueryable<Entidades> Entidades = AdEntidades.ListarEntidades();
            var DatosCliente = Entidades.SingleOrDefault(x => x.IdEntidad == ArchivosVenta.IdCliente);
            string Cliente = string.IsNullOrEmpty(DatosCliente?.NombreClave) ?
                $"{DatosCliente?.Apellido}_{DatosCliente?.Nombre}" :
                DatosCliente.NombreClave;

            if (ArchivosVenta.Archivos != null)
            {
                List<(string Hash, string Path)> DatosUpload = new UTL_Cloudinary().SubirArchivosCloudinary(ArchivosVenta.Archivos, Cliente);

                List<ArchivosVentas> InfoArchivosVentas = new();

                foreach (var Archivo in DatosUpload)
                {
                    InfoArchivosVentas.Add(new ArchivosVentas()
                    {
                        HashArchivo = Archivo.Hash,
                        IdVenta = ArchivosVenta.IdVenta ?? 0,
                        IdEstado = 1,
                        PathArchivo = Archivo.Path,
                    });
                }

                var (Resultado, error) = await AdVentas.GuardarArchivos(InfoArchivosVentas);

                if (error != null)
                    return new ContentResult()
                    {
                        Content = error.InnerException?.Message ?? error.Message,
                        ContentType = "application/json",
                        StatusCode = 400
                    };

                return new StatusCodeResult(200);
            }

            return new ContentResult()
            {
                Content = "No se encontraron archivos para subir",
                ContentType = "application/json",
                StatusCode = 400
            };

        }

        internal async Task<List<Ventas>> ObtenerVentasPendientesEntrega()
        {
            IQueryable<Ventas> QueryVentas = AdVentas.ListarVentas();

            List<Ventas> ListadoVentas = await QueryVentas.Where(x => x.IdEstadoVenta == 1).ToListAsync();

            int ProductosEntregados = 0;
            List<int> IdVentasPendientes = new List<int>();

            foreach (Ventas venta in ListadoVentas)
            {
                foreach (VentasDetalles DetallesVenta in venta.DetallesVenta)
                {
                    if (DetallesVenta.Entregados == DetallesVenta.Cantidad)
                    {
                        ProductosEntregados += 1;
                    }
                }

                if (ProductosEntregados < venta.DetallesVenta.Count)
                {
                    IdVentasPendientes.Add(venta.IdVenta);
                }

            }
            var ListadoVentasPendientes = QueryVentas.Where(x => IdVentasPendientes.Contains(x.IdVenta)).ToList();


            return ListadoVentasPendientes;


        }

        internal async Task<IActionResult> ListarProductos()
        {
            var Productos = AdProductos.ListarProdVentas(null);

            return new JsonResult(Productos);
        }

        internal async Task<IActionResult> ProcesarEstadoVenta(int id)
        {
            var Venta = await AdVentas.BuscarVenta(id);

            if (Venta == null)
                return new ContentResult()
                {
                    Content = "No se encontró la venta",
                    ContentType = "application/json",
                    StatusCode = 400
                };

            Venta.IdEstadoVenta = 2;

            Exception? Error = await AdVentas.CambiarEstado(Venta);

            if (Error != null)
                return new ContentResult()
                {
                    Content = Error.InnerException?.Message ?? Error.Message,
                    ContentType = "application/json",
                    StatusCode = 400
                };

            return new StatusCodeResult(200);


        }
    }
}
