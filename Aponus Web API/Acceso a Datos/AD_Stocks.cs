using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System.Reflection;
using System.Security.Claims;
using Z.EntityFramework.Plus;

namespace Aponus_Web_API.Acceso_a_Datos
{
    public class AD_Stocks
    {
        private readonly AponusContext AponusDBContext;
        private readonly IHttpContextAccessor Context;
        public AD_Stocks(AponusContext _aponusContext, IHttpContextAccessor context)
        {
            AponusDBContext = _aponusContext;
            Context = context;
        }

        public Productos StockProductos()
        {
            return new Productos(AponusDBContext);
        }

        public Insumos StockInsumos()
        {
            return new Insumos(AponusDBContext);
        }
        public class Productos
        {
            private readonly AponusContext AponusDBContext;
            public Productos(AponusContext _aponusContext)
            {
                AponusDBContext = _aponusContext;
            }

            public async Task<bool> Actualizar(Producto Producto)
            {
                using (var transaccion = await AponusDBContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var Existe = await AponusDBContext.Productos.FindAsync(Producto.IdProducto);

                        if (Existe != null)
                        {
                            Producto.Cantidad ??= Existe.Cantidad;

                            Producto.PrecioLista = (Producto.PrecioLista != 0 && Producto.PrecioLista != null) ? Producto.PrecioLista : Existe.PrecioLista;

                            Producto.PrecioFinal= (Producto.PrecioFinal != 0 && Producto.PrecioFinal != null) ? Producto.PrecioFinal : Existe.PrecioFinal;

                            Producto.PorcentajeGanancia??= Existe.PorcentajeGanancia;

                            Producto.IdDescripcion = Existe.IdDescripcion;
                            Producto.IdTipo = Existe.IdTipo;
                            Producto.DiametroNominal = Existe.DiametroNominal;
                            Producto.Tolerancia = Existe.Tolerancia;
                            Producto.IdEstado = Existe.IdEstado;

                            AponusDBContext.Entry(Existe).CurrentValues.SetValues(Producto);
                        }
                        else
                        {
                            await AponusDBContext.Productos.AddAsync(Producto);
                        }
                           

                        await AponusDBContext.SaveChangesAsync();
                        await transaccion.CommitAsync();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
        public class Insumos
        {
            private readonly AponusContext AponusDBContext;
            public Insumos(AponusContext _aponusContext)
            {
                AponusDBContext = _aponusContext;
            }

            public async Task<bool> Actualizar(StockInsumos stockInsumo)
            {
                using (var transaccion = await AponusDBContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var Existe = await AponusDBContext.stockInsumos.FindAsync(stockInsumo.IdInsumo);

                        if (Existe != null)
                        {

                            stockInsumo.Granallado = stockInsumo.Granallado ?? Existe?.Granallado ??0;
                            stockInsumo.Pintura = stockInsumo.Pintura ?? Existe?.Pintura ?? 0;
                            stockInsumo.Proceso = stockInsumo.Proceso ?? Existe?.Proceso ?? 0;
                            stockInsumo.Recibido = stockInsumo.Recibido ?? Existe?.Recibido ?? 0;
                            stockInsumo.Pendiente = stockInsumo.Pendiente ?? Existe?.Pendiente ?? 0;
                            stockInsumo.Moldeado = stockInsumo.Moldeado ?? Existe?.Moldeado ?? 0;

                            AponusDBContext.Entry(Existe!).CurrentValues.SetValues(stockInsumo);
                        }
                        else
                        {
                            await AponusDBContext.stockInsumos.AddAsync(stockInsumo);
                        }

                        await AponusDBContext.SaveChangesAsync();
                        await transaccion.CommitAsync();
                        return true;


                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }

            public async Task<List<StockInsumos>> ListarStockInsumos()
            {
                return await AponusDBContext.stockInsumos.ToListAsync();
            }
            
        }

        internal bool IncrementarStockProducto(DTOStockUpdate Actualizacion)
        {
            bool resultado = true;
            try
            {
                AponusDBContext.Productos
               .Where(x => x.IdProducto == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.Cantidad,
               AponusDBContext.Productos.
               Where(x => x.IdProducto == Actualizacion.IdExistencia).
               Select(x => x.Cantidad).SingleOrDefault() + Actualizacion.Cantidad));
            }
            catch (Exception)
            {

                resultado = false;
            }
            return resultado;

        }

        internal bool DisminuirStockProducto(DTOStockUpdate Actualizacion, AponusContext? AponusDBContext = null)
        {
            AponusDBContext ??= this.AponusDBContext;

            bool resultado = true;
            try
            {
                AponusDBContext.Productos
               .Where(x => x.IdProducto == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.Cantidad,
               AponusDBContext.Productos.
               Where(x => x.IdProducto == Actualizacion.IdExistencia).
               Select(x => x.Cantidad).SingleOrDefault() - Actualizacion.Cantidad));
            }
            catch (Exception)
            {
                resultado = false;
            }
            finally
            {
            }
            return resultado;

        }

        internal IActionResult ListarInsumosProducto(int? IdDescripcion = null)
        {

            List<DTOTipoInsumos> tipoInsumosList = AponusDBContext.ComponentesDetalles
                .Where(x=>x.IdEstado != 0)
                 .Join(AponusDBContext.ComponentesDescripcions,
                 Detalles => Detalles.IdDescripcion,
                 Descripciones => Descripciones.IdDescripcion,
                 (Detalles, Descripciones) => new { Detalles, Descripciones }
                 )
                 .Join(AponusDBContext.stockInsumos,
                        JoinResult => JoinResult.Detalles.IdInsumo,
                        Stock => Stock.IdInsumo,
                        (JoinResult, Stock) => new DTOTipoInsumos
                        {
                            IdDescripcion = JoinResult.Descripciones.IdDescripcion,
                            Descripcion = JoinResult.Descripciones.Descripcion,
                            especificacionesFormato = new List<DTOComponenteFormateado>
                            {
                                new()
                                {
                                    idComponente = JoinResult.Detalles.IdInsumo,
                                    Largo = JoinResult.Detalles.Longitud != null ? $"{JoinResult.Detalles.Longitud}mm" : "-",
                                    Espesor = JoinResult.Detalles.Espesor != null ? $"{JoinResult.Detalles.Espesor}mm" : "-",
                                    Perfil = JoinResult.Detalles.Perfil != null ? JoinResult.Detalles.Perfil.ToString() : "-",
                                    Diametro = JoinResult.Detalles.Diametro != null ? $"{JoinResult.Detalles.Diametro}mm" : "-",
                                    Peso= JoinResult.Detalles.Peso != null ? $"{JoinResult.Detalles.Peso}g" : "-",
                                    Altura = JoinResult.Detalles.Altura != null ? $"{JoinResult.Detalles.Altura}mm" : "-",
                                    Tolerancia = JoinResult.Detalles.Tolerancia != null ? JoinResult.Detalles.Tolerancia : "-",
                                    Recibido = Stock.Recibido != null ? Stock.Recibido.ToString() : "-",
                                    Granallado = Stock.Granallado != null ? Stock.Granallado.ToString() : "-",
                                    Pintura = Stock.Pintura != null ? Stock.Pintura.ToString() : "-",
                                    Proceso = Stock.Proceso != null ? Stock.Proceso.ToString() : "-",
                                    Moldeado = Stock.Moldeado != null ? Stock.Moldeado.ToString() : "-",
                                    Pendiente = Stock.Pendiente != null ? Stock.Pendiente.ToString(): "-",
                                    DiametroNominal = JoinResult.Detalles.DiametroNominal  != null ? JoinResult.Detalles.DiametroNominal.ToString() : "-",

                                }
                            } ?? new List<DTOComponenteFormateado>()
                        })
                 
                 .GroupBy(Result => new
                 {
                     Result.IdDescripcion,
                     Result.Descripcion
                 })
                 .Where(Filtros => (!IdDescripcion.HasValue || Filtros.Key.IdDescripcion == IdDescripcion.Value)) 
                 .Select(group => new DTOTipoInsumos
                 {
                     IdDescripcion = group.Key.IdDescripcion,
                     Descripcion = group.Key.Descripcion,
                     especificacionesFormato = group.Select(result => result.especificacionesFormato.Single()).ToList()
                 })
                 .OrderBy(x => x.Descripcion)
                 .AsEnumerable()
                 .ToList()
                 ;


            List<(string IdSuministro, string? Unidad)> Unidades = ObtenerUnidadesAlmacenamiento(tipoInsumosList
                .SelectMany(x => x.especificacionesFormato.Select(y => y.idComponente))
                .ToList());


            foreach (DTOTipoInsumos ListaInsumos in tipoInsumosList)
            {
                ListaInsumos.Columnas = new UTL_Productos().ObtenerColumnas(null, ListaInsumos.especificacionesFormato);

            }


            _ = tipoInsumosList.SelectMany(x => x.especificacionesFormato ?? new List<DTOComponenteFormateado>())
                 .Join(Unidades,
                     espec => espec.idComponente,
                     unidad => unidad.IdSuministro,
                     (espec, unidad) =>
                     {
                         espec.Pintura = espec.Pintura != null && !espec.Pintura.Equals("-") ? espec.Pintura + unidad.Unidad : espec.Pintura;
                         espec.Granallado = espec.Granallado != null && !espec.Granallado.Equals("-") ? espec.Granallado + unidad.Unidad : espec.Granallado;
                         espec.Proceso = espec.Proceso != null && !espec.Proceso.Equals("-") ? espec.Proceso + unidad.Unidad : espec.Proceso;
                         espec.Moldeado = espec.Moldeado != null && !espec.Moldeado.Equals("-") ? espec.Moldeado + unidad.Unidad : espec.Moldeado;
                         espec.Pendiente= espec.Pendiente!= null && !espec.Pendiente.Equals("-") ? espec.Pendiente + unidad.Unidad : espec.Pendiente;
                         espec.Recibido = espec.Recibido != null && !espec.Recibido.Equals("-") ? espec.Recibido + unidad.Unidad : espec.Recibido;

                         return tipoInsumosList;

                     })
                 .ToList();

            return new JsonResult(tipoInsumosList);


        }

        internal bool ActualizarStockInsumo(AponusContext AponusDBContext, DTOStockUpdate Actualizacion)
        {
            string Origen = Actualizacion.Origen?.Trim().ToUpper() ?? "";
            string Destino = Actualizacion.Destino?.Trim().ToUpper() ?? "";
            decimal Cantidad = Actualizacion.Cantidad ?? 0;

            StockInsumos? Insumo = AponusDBContext?.stockInsumos.FirstOrDefault(x => x.IdInsumo.Equals(Actualizacion.Id));

            if (Insumo != null)
            {
                PropertyInfo[] PropiedadesInsumo = Insumo.GetType().GetProperties();
                PropertyInfo? origen = PropiedadesInsumo.FirstOrDefault(x => x.Name.ToUpper().Contains(Origen));
                PropertyInfo? destino = PropiedadesInsumo.FirstOrDefault(x => x.Name.ToUpper().Contains(Destino));

                if (string.IsNullOrEmpty(Actualizacion.Origen) && (Actualizacion.Destino?.ToUpper() ?? "").Contains("PENDIENTE")) //CompraNavigation con mercaderia pendiente de entrega
                {
                    decimal CantidadDestino = (destino?.GetValue(Insumo) as decimal? ?? 0) + Cantidad;
                    destino?.SetValue(Insumo, CantidadDestino);
                    AponusDBContext!.Entry(Insumo).State = EntityState.Modified;
                    AponusDBContext.SaveChanges();

                    return true;
                }
                else if (string.IsNullOrEmpty(Actualizacion.Origen) && (Actualizacion.Destino?.ToUpper() ?? "").Contains("RECIBIDO")) //CompraNavigation con Mercaderia entregada al momento de la compra
                {
                    decimal CantidadDestino = (destino?.GetValue(Insumo) as decimal? ?? 0) + Cantidad;
                    destino?.SetValue(Insumo, CantidadDestino);
                    AponusDBContext!.Entry(Insumo).State = EntityState.Modified;
                    AponusDBContext.SaveChanges();

                    return true;
                }
                else if (!string.IsNullOrEmpty(Actualizacion.Origen) && !string.IsNullOrEmpty(Actualizacion.Destino)) //Movimiento interno/Ingreso de Mercaderia 
                {
                    decimal CantidadOrigen = (origen?.GetValue(Insumo) as decimal? ?? 0) - Cantidad;

                    if (CantidadOrigen < 0)
                        return false;

                    decimal CantidadDestino = (destino?.GetValue(Insumo) as decimal? ?? 0) + Cantidad;
                    origen?.SetValue(Insumo, CantidadOrigen);
                    destino?.SetValue(Insumo, CantidadDestino);
                    AponusDBContext!.Entry(Insumo).State = EntityState.Modified;
                    AponusDBContext.SaveChanges();

                    return true;

                }
                else if (!string.IsNullOrEmpty(Actualizacion.Origen) && Destino.Equals("PROCESO")) //Actualizacion de StockComponente Luego de Armar StockProductos
                {
                    Insumo.Proceso = Actualizacion.Cantidad;
                    AponusDBContext!.Entry(Insumo).State = EntityState.Modified;
                    AponusDBContext?.SaveChanges();

                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }


        }

        public StockInsumos? BuscarInsumo(string Insumo)
        {
            return AponusDBContext.stockInsumos.Where(x => x.IdInsumo == Insumo).Select(x => new StockInsumos()
            {
                IdInsumo = x.IdInsumo,
                Granallado = x.Granallado,
                Moldeado = x.Moldeado,
                Pintura = x.Pintura,
                Proceso = x.Proceso,
                Recibido = x.Recibido

            }).SingleOrDefault();

        }


        private List<(string IdSuministro, string? Unidad)> ObtenerUnidadesAlmacenamiento(List<string> Suministros)
        {
            List<(string IdSuministro, string? Unidad)> Unidades = AponusDBContext.ComponentesDetalles
                .Where(x => Suministros.Contains(x.IdInsumo))
                .Select(x => new ValueTuple<string, string?>(x.IdInsumo, x.IdAlmacenamiento)).ToList();

            return Unidades;

        }


      

        internal string? CrearDirectorioMovimientos_Local(string Proveedor)
        {
            try
            {
                string Aponus = Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), "Aponus");
                string DocumentosMovimientos = Path.Combine(Aponus, "Movimientos_Documentos");
                Proveedor = Path.Combine(DocumentosMovimientos, Proveedor);
                string FechaMovimiento = Path.Combine(Proveedor, UTL_Fechas.ObtenerFechaHora().ToString("dd-MM-yyyy"));

                //--Crear/Validar Directorio para la copia de DescargarArchivos 

                _ = !Directory.Exists(Aponus) ? Directory.CreateDirectory(Aponus) : null;
                _ = !Directory.Exists(DocumentosMovimientos) ? Directory.CreateDirectory(DocumentosMovimientos) : null;
                _ = !Directory.Exists(Proveedor) ? Directory.CreateDirectory(Proveedor) : null;
                _ = !Directory.Exists(FechaMovimiento) ? Directory.CreateDirectory(FechaMovimiento) : null;

                return FechaMovimiento;
            }
            catch (Exception)
            {
                return null;
            }


        }

        internal List<ArchivosMovimientosStock> CopiarArchivosMovimientos_Local(List<IFormFile> Archivos, string Directorio)
        {
            List<ArchivosMovimientosStock> MovimientosStockArchivosList = new();
            string[] NombresArchivos = new string[Archivos.Count];

            for (int i = 0; i < NombresArchivos.Length; i++)
            {
                NombresArchivos[i] = Guid.NewGuid().ToString();
                MovimientosStockArchivosList.Add(new ArchivosMovimientosStock()
                {
                    HashArchivo = NombresArchivos[i].ToString(),
                });
            }

            //Copiar DescargarArchivos
            int x = 0;

            foreach (IFormFile Archivo in Archivos)
            {
                var ExtensionArchivo = Path.GetExtension(Archivo.FileName);
                string NombreArchivo = NombresArchivos[x];
                ArchivosMovimientosStock? UPDATEMovimientosStock_Archivos = MovimientosStockArchivosList.FirstOrDefault(x => x.HashArchivo.Equals(NombreArchivo));

                var RutaArchivo = Path.Combine(Directorio, Path.GetFileNameWithoutExtension(NombreArchivo) + ExtensionArchivo);

                using (var FlujoArchivos = new FileStream(RutaArchivo, FileMode.Create))
                {
                    Archivo.CopyTo(FlujoArchivos);
                };

                if (UPDATEMovimientosStock_Archivos != null)
                {
                    UPDATEMovimientosStock_Archivos.PathArchivo = RutaArchivo.ToString();
                    UPDATEMovimientosStock_Archivos.HashArchivo = NombreArchivo;
                    UPDATEMovimientosStock_Archivos.MimeType = AD_Movimientos.ObtenerMimeType(RutaArchivo.ToString());
                }
                x++;

            }

            return MovimientosStockArchivosList;
        }

        internal bool GuardarDatosArchivosMovimiento(AponusContext AponusDBContext, List<ArchivosMovimientosStock> DatosArchivos)
        {
            try
            {
                int IdMovimiento = DatosArchivos.Select(x => x.IdMovimiento).First();
                DatosArchivos.ForEach(x => x.StockMovimiento = AponusDBContext.Stock_Movimientos.First(y => y.IdMovimiento == IdMovimiento));
                AponusDBContext.ArchivosStock.AddRange(DatosArchivos);
                AponusDBContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            };
        }

        internal int? GuardarDatosMovimiento(AponusContext AponusDBContext, Stock_Movimientos Movimiento)
        {
            string Usuario = Context.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            string insertQuery = @"INSERT INTO ""STOCK_MOVIMIENTOS"" (""USUARIO_CREADO"", ""FECHA_HORA_CREADO"",""ORIGEN"",""DESTINO"",""ID_PROVEEDOR"", ""ID_ESTADO_MOVIMIENTO"") 
                                    VALUES (@USUARIO_CREADO, @FECHA_HORA_CREADO,@ORIGEN,@DESTINO,  @ID_PROVEEDOR, 1)";


            try
            {
                AponusDBContext.Database.ExecuteSqlRaw(insertQuery,
                                                         new NpgsqlParameter("@USUARIO_CREADO", Usuario) { NpgsqlDbType = NpgsqlDbType.Varchar },
                                                         new NpgsqlParameter("@FECHA_HORA_CREADO", Movimiento.FechaHoraCreado) { NpgsqlDbType = NpgsqlDbType.Timestamp },
                                                         new NpgsqlParameter("@ORIGEN", Movimiento.Origen) { NpgsqlDbType = NpgsqlDbType.Varchar },
                                                         new NpgsqlParameter("@DESTINO", Movimiento.Destino) { NpgsqlDbType = NpgsqlDbType.Varchar },
                                                         new NpgsqlParameter("@ID_PROVEEDOR", Movimiento.IdProveedor) { NpgsqlDbType = NpgsqlDbType.Integer }
                                                         /*new NpgsqlParameter("@USUARIO_MODIFICA", Movimiento.ModificadoUsuario) { NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar}*/);

                int? IdMovimiento = AponusDBContext.Stock_Movimientos.Select(x => x.IdMovimiento).Max();

                return IdMovimiento;
            }
            catch (DbUpdateException)
            {
                return null;
            }

        }


        internal bool GuardarSuministrosMovimiento(AponusContext AponusDBContext, List<SuministrosMovimientosStock> Suministros)
        {

            foreach (var item in Suministros)
            {
                item.IdEstado = 1;
                item.EstadosSuministrosMovimientosStockNavigation = AponusDBContext.EstadoSuministrosMovimientosStock.FirstOrDefault(x => x.IdEstado == 1);
            }

            try
            {
                foreach (var suministro in Suministros)
                {
                    var Existente = AponusDBContext.SuministrosMovimientoStock
                        .Where(x => x.IdMovimiento == suministro.IdMovimiento && x.IdSuministro == suministro.IdSuministro)
                        .FirstOrDefault();

                    if (Existente != null)
                        AponusDBContext.Entry(Existente).CurrentValues.SetValues(suministro);
                    else
                        AponusDBContext.Add(suministro);
                }

                AponusDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal List<DTOTiposProductos> ListarProductos()
        {

            List<DTOTiposProductos> ListadoProductos = AponusDBContext.Producto_Tipo_Descripcion
                .Join(AponusDBContext.ProductosTipos,
                aux => aux.IdTipo,
                ptd => ptd.IdTipo,
                (aux, ptd) => new { aux, ptd })
                .Join(AponusDBContext.ProductosDescripcions,
                auxPtd => auxPtd.aux.IdDescripcion,
                pDesc => pDesc.IdDescripcion,
                (auxPtd, pDesc) => new { auxPtd, pDesc })
                .AsQueryable()
                .Select(x => new DTOTiposProductos()
                {

                    IdTipo = x.auxPtd.ptd.IdTipo,
                    DescripcionTipo = x.auxPtd.ptd.DescripcionTipo ?? "",
                    DescripcionProductos = AponusDBContext.ProductosDescripcions
                    .Where(pd => pd.IdDescripcion == x.pDesc.IdDescripcion)
                    .Select(pd => new DTODescripcionesProductos()
                    {
                        IdDescripcion = pd.IdDescripcion,
                        NombreDescripcion = pd.DescripcionProducto ?? "",
                        Productos = pd.Productos
                        .Where(prod => prod.IdDescripcion == pd.IdDescripcion && prod.IdTipo == x.auxPtd.ptd.IdTipo && prod.IdEstado != 0)
                        .Select(x => new DTOStockProductos()
                        {
                            IdProducto = x.IdProducto,
                            IdTipo = x.IdTipo,
                            Cantidad = x.Cantidad != null ? x.Cantidad.ToString() + "Ud." : "-",
                            DiametroNominal = x.DiametroNominal != null ? x.DiametroNominal.ToString() + "mm" : "-",
                            PrecioLista = x.PrecioLista != null ? x.PrecioLista.ToString() : "-",
                            PrecioFinal = x.PrecioFinal != null ? x.PrecioFinal.ToString() : "-",
                            Tolerancia = !string.IsNullOrEmpty(x.Tolerancia) ? x.Tolerancia : "-",
                            PorcentajeGanancia = x.PorcentajeGanancia != null ? x.PorcentajeGanancia.ToString() + "%" : "-"


                        })
                        .OrderBy(prod => Convert.ToInt32(prod.DiametroNominal ?? "".Replace("mm", "").Replace("-", "")))
                        .ToList()

                    })
                    .OrderBy(x => x.NombreDescripcion)
                    .ToList(),

                })
                .OrderBy(x => x.DescripcionTipo)
                .ToList();




            return ListadoProductos;
        }
    }
}
