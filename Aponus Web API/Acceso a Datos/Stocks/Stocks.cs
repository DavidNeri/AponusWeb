using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Data.SqlClient;
using Z.EntityFramework.Plus;


namespace Aponus_Web_API.Acceso_a_Datos.Stocks
{
    public class Stocks
    {
        private readonly AponusContext AponusDBContext;
        public Stocks() { AponusDBContext = new AponusContext(); }
        int? ValorAnteriorInt=null;
        decimal? ValorAnteriorDec=null;

        public class Productos : Stocks
        {
            public async Task<bool> Actualizar(Producto Producto)
            {
                using (var transaccion = await AponusDBContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var Existe = await AponusDBContext.Productos.FindAsync(Producto.IdProducto);

                        if (Existe != null)
                            AponusDBContext.Entry(Existe).CurrentValues.SetValues(Producto);
                        else
                            await AponusDBContext.Productos.AddAsync(Producto);

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
        public class Insumos : Stocks
        {
            public async Task<bool> Actualizar(StockInsumos stockInsumo)
            {
                using (var transaccion = await AponusDBContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var Existe = await AponusDBContext.stockInsumos.FindAsync(stockInsumo.IdInsumo);

                        if (Existe != null)
                            AponusDBContext.Entry(Existe).CurrentValues.SetValues(stockInsumo);
                        else
                            await AponusDBContext.stockInsumos.AddAsync(stockInsumo);

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
        


            internal bool IncrementarStockProducto(ActualizacionStock Actualizacion)
        {
            bool resultado = true;
            try
            {
                 AponusDBContext.Productos
                .Where(x => x.IdProducto == Actualizacion.IdExistencia)
                .ExecuteUpdate(x => x.SetProperty(x => x.Cantidad,
                AponusDBContext.Productos.
                Where(x => x.IdProducto == Actualizacion.IdExistencia).
                Select(x => x.Cantidad).SingleOrDefault() + Actualizacion.Valor));
            }
            catch (Exception)
            {

                resultado=false;
            }
            return resultado;
        }

        internal bool DisminuirStockProducto(ActualizacionStock Actualizacion, AponusContext? AponusDBContext = null)
        {
            if (AponusDBContext == null)
                AponusDBContext = new AponusContext();

            bool resultado = true;
            try
            {
                AponusDBContext.Productos
               .Where(x => x.IdProducto == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.Cantidad,
               AponusDBContext.Productos.
               Where(x => x.IdProducto == Actualizacion.IdExistencia).
               Select(x => x.Cantidad).SingleOrDefault() - Actualizacion.Valor));
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

        internal bool SetCantidadProducto(ActualizacionStock Actualizacion)
        {
            bool resultado = true;
            try
            {
                AponusDBContext.Productos
               .Where(x => x.IdProducto == Actualizacion.Id)
               .ExecuteUpdate(x => x.SetProperty(x => x.Cantidad, Actualizacion.Valor));
            }
            catch (Exception)
            {

                resultado=false;
            }
            return  resultado;
           
        }



        internal  IActionResult ListarInsumosProducto(int? IdDescripcion=null)
        {          

            List<TipoInsumos> tipoInsumosList =   AponusDBContext.ComponentesDetalles
                 .Join(AponusDBContext.ComponentesDescripcions,
                 Detalles => Detalles.IdDescripcion,
                 Descripciones => Descripciones.IdDescripcion,
                 (Detalles, Descripciones) => new { Detalles, Descripciones }
                 )
                 .Join(AponusDBContext.stockInsumos,
                        JoinResult => JoinResult.Detalles.IdInsumo,
                        Stock => Stock.IdInsumo,
                        (JoinResult, Stock) => new TipoInsumos
                        {
                            IdDescripcion = JoinResult.Descripciones.IdDescripcion,
                            Descripcion = JoinResult.Descripciones.Descripcion,
                            especificacionesFormato = new List<DTOComponenteFormateado>
                            {
                                new()
                                {
                                    //IdDescripcion = JoinResult.Detalles.IdDescripcion,
                                    idComponente = JoinResult.Detalles.IdInsumo,
                                    Largo = JoinResult.Detalles.Longitud != null ? $"{JoinResult.Detalles.Longitud}mm" : "-",
                                    Espesor = JoinResult.Detalles.Espesor != null ? $"{JoinResult.Detalles.Espesor}mm" : "-",
                                    Perfil = JoinResult.Detalles.Perfil != null ? JoinResult.Detalles.Perfil.ToString() : "-",
                                    Diametro = JoinResult.Detalles.Diametro != null ? $"{JoinResult.Detalles.Diametro}mm" : null,
                                    Peso= JoinResult.Detalles.Peso != null ? $"{JoinResult.Detalles.Peso}g" : "-",
                                    Altura = JoinResult.Detalles.Altura != null ? $"{JoinResult.Detalles.Altura}mm" : "-",
                                    Tolerancia = JoinResult.Detalles.Tolerancia != null ? JoinResult.Detalles.Tolerancia : "-",
                                    Recibido = Stock.Recibido != null ? Stock.Recibido.ToString() : "-",
                                    Granallado = Stock.Granallado != null ? Stock.Granallado.ToString() : "-",
                                    Pintura = Stock.Pintura != null ? Stock.Pintura.ToString() : "-",
                                    Proceso = Stock.Proceso != null ? Stock.Proceso.ToString() : "-",
                                    Moldeado = Stock.Moldeado != null ? Stock.Moldeado.ToString() : "-",
                                    DiametroNominal = JoinResult.Detalles.DiametroNominal  != null ? JoinResult.Detalles.DiametroNominal.ToString() : "-",                                   

                                }
                            }
                        })                
                 
                 .GroupBy(Result => new
                 {
                     Result.IdDescripcion,
                     Result.Descripcion
                 })
                 .Where(Filtros=>(!IdDescripcion.HasValue || Filtros.Key.IdDescripcion==IdDescripcion.Value))
                 .Select(group => new TipoInsumos
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


            foreach (TipoInsumos ListaInsumos in tipoInsumosList)
            {
                ListaInsumos.Columnas = new ColumnasJson().ObtenerColumnas(null, ListaInsumos.especificacionesFormato);

            }

            tipoInsumosList.SelectMany(x => x.especificacionesFormato)
                 .Join(Unidades,
                     espec => espec.idComponente,
                     unidad => unidad.IdSuministro,
                     (espec, unidad) => 
                     {
                         espec.Pintura = !espec.Pintura.Equals("-") ? espec.Pintura + unidad.Unidad : espec.Pintura;
                         espec.Granallado = !espec.Granallado.Equals("-") ? espec.Granallado + unidad.Unidad : espec.Granallado;
                         espec.Proceso= !espec.Proceso.Equals("-") ? espec.Proceso + unidad.Unidad : espec.Proceso;
                         espec.Moldeado= !espec.Moldeado.Equals("-") ? espec.Moldeado + unidad.Unidad : espec.Moldeado;
                         espec.Recibido = !espec.Recibido.Equals("-") ? espec.Recibido + unidad.Unidad : espec.Recibido;

                         return tipoInsumosList;

                     })
                 .ToList();

            return new JsonResult(tipoInsumosList);


        }       
        internal bool IncrementarStockInsumo(AponusContext AponusDBContext, ActualizacionStock Actualizacion, string Prop)
        {
            bool result = false;
            bool saveChanges = false;

            PropertyInfo? Propiedad = typeof(StockInsumos).GetProperties().FirstOrDefault(p => p.Name.ToUpper().Contains(Prop.ToUpper()));
            if (AponusDBContext == null)
            {
                AponusDBContext = new AponusContext();
                saveChanges = true;
            }
                

            try
            {
                var elementos = AponusDBContext.stockInsumos.Where(x => x.IdInsumo == Actualizacion.Id).ToList();
                
                foreach (var elemento in elementos)
                {
                        decimal? valorSumar = Actualizacion.Valor ?? 0;
                        var valorActual = (decimal?)Propiedad?.GetValue(elemento);

                        if (valorActual == null)
                            valorActual = 0;

                        decimal? nuevoValor = (valorActual ?? 0) + valorSumar;

                        if (Propiedad != null)
                            Propiedad.SetValue(elemento, nuevoValor);

                    if (saveChanges)
                        AponusDBContext.SaveChanges();

                }
                
                result = true;
                return result;
                
            }
            catch (Exception){return false;}
        }

        internal bool DescontarStockInsumo(AponusContext AponusDBContext, ActualizacionStock Actualizacion, string Prop)
        {
            bool result = false;
            bool saveChanges = false;

            PropertyInfo? Propiedad = typeof(StockInsumos).GetProperties().FirstOrDefault(p => p.Name.ToUpper().Contains(Prop.ToUpper()));
            if (AponusDBContext == null)
            {
                AponusDBContext = new AponusContext();
                saveChanges = true;
            }
                

            try
            {
                var elementos = AponusDBContext.stockInsumos.Where(x => x.IdInsumo == Actualizacion.Id).ToList();
                
                foreach (var elemento in elementos)
                
                {
                        decimal? valorSumar = Actualizacion.Valor ?? 0;
                        var valorActual     = (decimal?)Propiedad?.GetValue(elemento);

                        if (valorActual     == null)
                            valorActual     = 0;

                        decimal? nuevoValor = (valorActual ?? 0) - valorSumar;

                        if (Propiedad != null)
                            Propiedad.SetValue(elemento, nuevoValor);
                    
                    if (saveChanges)
                        AponusDBContext.SaveChanges();
                
                }
                    result = true;
                    return result;
                                   
            }
            catch (Exception){return false;}
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
               
            
        internal bool NewSetearStockInsumo(ActualizacionStock Actualizacion)
        {
            PropertyInfo? Propiedad = typeof(StockInsumos).GetProperties().FirstOrDefault(p => p.Name.Contains(Actualizacion.Destino));
            bool resultado = true;
            try
            {
                var elementos = AponusDBContext.stockInsumos
                       .Where(x => x.IdInsumo == Actualizacion.Id)
                       .ToList();

                foreach (var elemento in elementos)
                {


                    if (Propiedad != null)
                    {
                        Propiedad.SetValue(elemento, Actualizacion.Valor);
                    }
                }

                AponusDBContext.SaveChanges(); // Guardar los cambios en la base de datos
                return resultado;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal string? CrearDirectorioMovimientos_Local(string Proveedor)
        {
            try
            {
                string Aponus = Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), "Aponus");
                string DocumentosMovimientos = Path.Combine(Aponus, "Movimientos_Documentos");
                Proveedor = Path.Combine(DocumentosMovimientos, Proveedor);
                string FechaMovimiento = Path.Combine(Proveedor,Fechas.ObtenerFechaHora().ToString("dd-MM-yyyy")) ;               

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
                ArchivosMovimientosStock UPDATEMovimientosStock_Archivos = MovimientosStockArchivosList.FirstOrDefault(x => x.HashArchivo.Equals(NombreArchivo));

                var RutaArchivo = Path.Combine(Directorio, Path.GetFileNameWithoutExtension(NombreArchivo) + ExtensionArchivo);

                using (var FlujoArchivos = new FileStream(RutaArchivo, FileMode.Create))
                {
                    Archivo.CopyTo(FlujoArchivos);
                };
                UPDATEMovimientosStock_Archivos.PathArchivo = RutaArchivo.ToString();
                UPDATEMovimientosStock_Archivos.HashArchivo = NombreArchivo;
                UPDATEMovimientosStock_Archivos.MimeType = MovimientosStock.ObtenerMimeType(RutaArchivo.ToString());
                x++;

            }

            return MovimientosStockArchivosList;
        }

        internal bool GuardarDatosArchivosMovimiento(AponusContext AponusDBContext,List<ArchivosMovimientosStock> DatosArchivos)
        {
            try
            {
                    AponusDBContext.ArchivosStock.AddRange(DatosArchivos);
                    return true;

                    }
                    catch (Exception)
                    {   

                    return false;
            }
            
                
            

        }

        internal int? GuardarDatosMovimiento(AponusContext AponusDBContext, Stock_Movimientos Movimiento)
        {
            string insertQuery = "INSERT INTO Stock_Movimientos (USUARIO_CREADO, FECHA_HORA_CREADO,  ID_PROVEEDOR_ORIGEN, ID_PROVEEDOR_DESTINO, ID_ESTADO,  USUARIO_MODIFICA) " +
                                                        "VALUES (@USUARIO_CREADO, @FECHA_HORA_CREADO,  @ID_PROVEEDOR_ORIGEN, @ID_PROVEEDOR_DESTINO, 1,  @USUARIO_MODIFICA)";

            try
            {
                AponusDBContext.Database.ExecuteSqlRaw(insertQuery,
                                                             new SqlParameter("@USUARIO_CREADO", Movimiento.CreadoUsuario),
                                                             new SqlParameter("@FECHA_HORA_CREADO", Movimiento.FechaHoraCreado),
                                                             new SqlParameter("@ID_PROVEEDOR_ORIGEN", Movimiento.IdProveedorOrigen),
                                                             new SqlParameter("@ID_PROVEEDOR_DESTINO", Movimiento.IdProveedorDestino),
                                                             new SqlParameter("@USUARIO_MODIFICA", Movimiento.ModificadoUsuario));
                
                int? IdMovimiento = AponusDBContext.Stock_Movimientos.Select(x => x.IdMovimiento).Max();

                return IdMovimiento;
            }
            catch (DbUpdateException ex )
            {
                return null;
            }

        }


        internal  bool GuardarSuministrosMovimiento(AponusContext AponusDBContext, List<SuministrosMovimientosStock> Suministros)
        {
            Suministros.ForEach(x=>x.IdEstado= 1);
            try
            {
                foreach (var suministro in Suministros)
                {
                    var Existente =  AponusDBContext.SuministrosMovimientoStock.Where(x=>x.IdMovimiento==suministro.IdMovimiento && x.IdSuministro==suministro.IdSuministro).FirstOrDefault();
                    

                    if (Existente != null)
                    {
                        AponusDBContext.Entry(Existente).CurrentValues.SetValues(suministro);
                    }else
                    {
                        AponusDBContext.SuministrosMovimientoStock.Add(suministro);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal List<DTOTiposProductos>  ListarProductos()
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
                    DescripcionTipo = x.auxPtd.ptd.DescripcionTipo,
                    DescripcionProductos = AponusDBContext.ProductosDescripcions
                    .Where(pd => pd.IdDescripcion == x.pDesc.IdDescripcion)
                    .Select(pd => new DTODescripcionesProductos()
                    {
                        IdDescripcion = pd.IdDescripcion,
                        NombreDescripcion = pd.DescripcionProducto,
                        Productos = pd.Productos
                        .Where(prod => prod.IdDescripcion == pd.IdDescripcion && prod.IdTipo == x.auxPtd.ptd.IdTipo && prod.IdEstado != 0)
                        .Select(x => new DTOStockProductos()
                        {
                            IdProducto = x.IdProducto,
                            IdTipo = x.IdTipo,
                            Cantidad = x.Cantidad!=null ? x.Cantidad.ToString() + "Ud." : "-",
                            DiametroNominal = x.DiametroNominal != null ? x.DiametroNominal.ToString() + "mm" : "-",
                            PrecioLista = x.PrecioLista != null ? x.PrecioLista.ToString() : "-",
                            PrecioFinal = x.PrecioFinal != null ? x.PrecioFinal.ToString() : "-",
                            Tolerancia = !string.IsNullOrEmpty(x.Tolerancia) ? x.Tolerancia : "-",
                            PorcentajeGanancia =x.PorcentajeGanancia != null ? x.PorcentajeGanancia.ToString() +"%" :"-"


                        })
                        .OrderBy(prod => Convert.ToInt32(prod.DiametroNominal.Replace("mm", "").Replace("-","")))
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
