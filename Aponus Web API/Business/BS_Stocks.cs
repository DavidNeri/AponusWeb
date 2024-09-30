using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Acceso_a_Datos.Entidades;
using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Z.EntityFramework.Plus;
using Aponus_Web_API.Support;
using System.Reflection;

namespace Aponus_Web_API.Business
{
    public class BS_Stocks : Stocks
    {
        internal JsonResult ListarProductos(string? typeId, int? idDescription)
        {
            List<DTOTiposProductos> ListadoProductos = new Stocks().ListarProductos();


            if (typeId != null && idDescription != null)
            {
                List<DTOTiposProductos> Lista = ListadoProductos
                    .Where(x => x.IdTipo == typeId && x.DescripcionProductos
                    .Any(d => d.IdDescripcion == idDescription))
                    .ToList();

                Lista.ForEach(tpd => tpd.DescripcionProductos.ForEach(dpp =>
                {
                    dpp.Columnas = new ColumnasJson().ObtenerColumnas(dpp.Productos);
                }));


                return new JsonResult(Lista);
            }
            else if (typeId != null)
            {
                List<DTOTiposProductos> Lista = ListadoProductos
                    .Where(x => x.IdTipo == typeId)
                    .ToList();

                Lista.ForEach(tpd => tpd.DescripcionProductos.ForEach(dpp =>
                {
                    dpp.Columnas = new ColumnasJson().ObtenerColumnas(dpp.Productos);
                }));

                return new JsonResult(Lista);
            }
            else if (idDescription != null)
            {

                List<DTOTiposProductos> Lista = ListadoProductos
                    .Where(x => x.DescripcionProductos
                    .Any(x => x.IdDescripcion == idDescription))
                    .ToList();

                Lista.ForEach(tpd => tpd.DescripcionProductos.ForEach(dpp =>
                {
                    dpp.Columnas = new ColumnasJson().ObtenerColumnas(dpp.Productos);
                }));
                return new JsonResult(Lista);
            }
            else
            {
                ListadoProductos.ForEach(tpd => tpd.DescripcionProductos.ForEach(dpp =>
                {
                    dpp.Columnas = new ColumnasJson().ObtenerColumnas(dpp.Productos);
                }));

                return new JsonResult(ListadoProductos);
            }

        }

        internal IActionResult ObtenerDatosInsumos(int? IdDescripcion)
        {
            return new Stocks().ListarInsumosProducto(IdDescripcion);

        }

        internal void ActualizarProducto_Agregar(ActualizacionStock Actualizacion)
        {
            try
            {
                new Stocks().IncrementarStockProducto(Actualizacion);
            }
            catch (Exception)
            {


            }

        }
       
        internal void ActualizarProducto_Descontar(ActualizacionStock Actualizacion)
        {
            try
            {
                AponusContext DBContext = new AponusContext();

                DBContext.stockInsumos.Select(x=>x.Granallado);

                new Stocks().DisminuirStockProducto(Actualizacion);
            }
            catch (Exception)
            {


            }

        }

        internal void ActualizarProducto_NuevoValor(ActualizacionStock Actualizacion)
        {
            try
            {
                new Stocks().SetCantidadProducto(Actualizacion);
            }
            catch (Exception)
            {


            }

        }        
        internal IActionResult ProcesarDatosMovimiento(DTOMovimientosStock Movimiento)
        {
            Stocks stocks = new Stocks();
            bool Rollback = false;
            
            using (AponusContext AponusDbContext = new AponusContext())
            {
                using (var transaccion = AponusDbContext.Database.BeginTransaction())
                {
                    foreach (DTOSuministrosMovimientosStock suministro in Movimiento.Suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
                    {
                        if (!stocks.ActualizarStockInsumo(AponusDbContext,new ActualizacionStock()
                        {
                            Id = suministro.IdSuministro,
                            Origen = Movimiento.Origen,
                            Destino = Movimiento.Destino,
                            Valor = Convert.ToDecimal(suministro.Cantidad)
                        }))
                            Rollback = true;
                    }

                    int? IdMovimiento = stocks.GuardarDatosMovimiento(AponusDbContext, new Stock_Movimientos
                    {
                        CreadoUsuario = Movimiento.UsuarioCreacion ?? "ERROR",
                        ModificadoUsuario = Movimiento.UsuarioModificacion,
                        FechaHoraCreado = Fechas.ObtenerFechaHora(),
                        IdProveedorOrigen = Movimiento.IdProveedorOrigen ?? 0,
                        IdProveedorDestino = Movimiento.IdProveedorDestino ?? 0,
                        Tipo = Movimiento.Tipo,
                        Destino = !string.IsNullOrEmpty(Movimiento.Destino) ? Movimiento.Destino.ToUpper() : "",
                        Origen = !string.IsNullOrEmpty(Movimiento.Origen) ? Movimiento.Origen.ToUpper() : "",
                    });

                    if (IdMovimiento == null) Rollback = true;

                    List<SuministrosMovimientosStock> Suministros = (Movimiento.Suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
                        .Select(x => new SuministrosMovimientosStock()
                        {
                            IdMovimiento = IdMovimiento ?? 0,
                            Cantidad = Convert.ToDecimal(x.Cantidad),
                            IdSuministro = x.IdSuministro,                           

                        })
                        .ToList();

                    if (!stocks.GuardarSuministrosMovimiento(AponusDbContext, Suministros)) Rollback = true;

                    //Obtener el Nombre del IdProveedor de Destino
                    IActionResult Proveedores =  BS_Entidades.Listar(Movimiento.IdProveedorDestino ?? 0, 0, 0);
                    DTOEntidades? proveedor = new DTOEntidades();

                    if (Proveedores is JsonResult jsonProveedores && jsonProveedores.Value!=null && jsonProveedores.Value is IEnumerable<DTOEntidades> ProveedoresList)
                    {
                        proveedor = ProveedoresList.FirstOrDefault(x => x.IdEntidad == Movimiento.IdProveedorDestino);
                        
                    }
                    string? NombreCompletoProveedor = proveedor?.Apellido + "_" + proveedor?.Nombre;
                    string? NombreClave = proveedor?.NombreClave; 
                    //Obtener el Nombre del IdProveedor de Destino

                    if (Movimiento.Archivos != null && Movimiento.Archivos.Count > 0)
                    {
                        List<ArchivosMovimientosStock> DatosArchivosMovimiento = new CloudinaryService().SubirArchivosMovimiento(Movimiento.Archivos,
                        string.IsNullOrEmpty(NombreClave) ? NombreCompletoProveedor : NombreClave);

                        if (DatosArchivosMovimiento.Count == 0) Rollback = true;

                        Movimiento.IdMovimiento = IdMovimiento;
                        DatosArchivosMovimiento.ForEach(x => x.IdMovimiento = IdMovimiento ?? 0);
                        if (!stocks.GuardarDatosArchivosMovimiento(AponusDbContext, DatosArchivosMovimiento)) Rollback = true;

                    }                    

                    if (Rollback)
                    {
                        transaccion.Rollback();
                        return new ContentResult()
                        {
                            Content = $"Error interno, no se aplicaron los cambios",
                            ContentType = "Aplication/Json",
                            StatusCode = 500,
                        };
                    }else
                    {
                        AponusDbContext.Database.CommitTransaction();
                        AponusDbContext.SaveChanges();
                        AponusDbContext.Dispose();
                        return new StatusCodeResult(200);
                    }              
                    
                }

            }
            
        
        }

        internal IActionResult ActualizarStockProducto(ActualizacionStock Actualizacion)
        {
            List<(
                string IdComponente,
                bool? resultado,
                decimal? ValorAnterior,
                decimal? NuevoValor)>
                Resultados = new List<(string, bool?, decimal?, decimal?)>();
            
            Actualizacion.Valor = Actualizacion.Valor ?? 0;


            switch (Actualizacion.Operador)
            {
                case "+":
                    

                    JsonResult Componentes = new ComponentesProductos().ObtenerComponentesFormateados(new DTODetallesProducto()
                    {
                        IdProducto = Actualizacion.Id,
                        Cantidad = Convert.ToInt32(Actualizacion.Valor)
                    });

                    List<DTOProductoComponente> ListaComponentes = Componentes.Value as List<DTOProductoComponente>;
                    List<string> IdComponenteList = new List<string>();

                    foreach (DTOProductoComponente DetallesComponentesProducto in ListaComponentes)
                    {
                        List<DTOStock> ComponentesList = DetallesComponentesProducto.StockComponente;                        

                        foreach (DTOStock Componente in ComponentesList)
                        {

                            if (Componente.Longitud != null)
                            {
                                ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                {
                                    Id = Componente.IdInsumo,
                                    Valor = Componente.Longitud,
                                    Origen = "PINTURA",
                                    Destino="PROCESO",

                                };

                                StockInsumos? StockComponente = new Stocks().BuscarInsumo(Componente.IdInsumo);
                                Resultados.Add((StockComponente.IdInsumo, null, StockComponente.Proceso, ComponenteActualizar.Valor));

                                if (StockComponente.Proceso != null & ComponenteActualizar.Valor != null)
                                {
                                    if ((int?)StockComponente.Proceso < (int?)ComponenteActualizar.Valor)
                                    {
                                        IdComponenteList.Add(DetallesComponentesProducto.Descripcion);
                                    }
                                }
                            }
                            else if (Componente.Peso != null)
                            {
                                ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                {
                                    Id = Componente.IdInsumo,
                                    Valor = Componente.Peso
                                };

                                StockInsumos? StockComponente = new Stocks().BuscarInsumo(Componente.IdInsumo);
                                Resultados.Add((StockComponente.IdInsumo, null, StockComponente.Proceso, ComponenteActualizar.Valor));

                                if (StockComponente.Proceso != null & ComponenteActualizar.Valor != null)
                                {
                                    if (StockComponente.Proceso < ComponenteActualizar.Valor)
                                    {
                                        IdComponenteList.Add(DetallesComponentesProducto.Descripcion);
                                    }
                                }
                            }
                            else if (Componente.Cantidad != null)
                            {
                                ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                {
                                    Id = Componente.IdInsumo,
                                    Valor = Componente.Cantidad
                                };

                                StockInsumos? StockComponente = new Stocks().BuscarInsumo(Componente.IdInsumo);
                                Resultados.Add((StockComponente.IdInsumo, null, StockComponente.Proceso, ComponenteActualizar.Valor));

                                if (StockComponente.Proceso != null & ComponenteActualizar.Valor != null)
                                {
                                    if (StockComponente.Proceso < ComponenteActualizar.Valor)
                                    {
                                        IdComponenteList.Add(DetallesComponentesProducto.Descripcion);
                                    }

                                }
                            }
                        }

                    }

                    if (IdComponenteList.Count > 0)
                    {
                        string ValoresLista = String.Join("\n- ", IdComponenteList);

                        var Resultado = new ObjectResult("La cantidad de Stock en estado 'En Proceso' de los siguientes insumos es inferior " +
                                                            "a la cantidad requerida para agregar el producto:\n- " + ValoresLista)
                        {
                            StatusCode = 500,
                        };
                        return Resultado;

                    }
                    else
                    {
                        foreach (DTOProductoComponente DetallesComponentesProducto in ListaComponentes)
                        {
                            List<DTOStock> ComponentesList = DetallesComponentesProducto.StockComponente;

                            foreach (DTOStock Componente in ComponentesList)
                            {
                                if (Componente.Longitud != null)
                                {
                                    ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                    {
                                        Id = Componente.IdInsumo,
                                        Valor = Componente.Longitud
                                    };
                                    //Guardart los ccomponentes, valores y bool del resutado de descontar enu una lista para 
                                    //verificar si alguno dio falso y si dio falso, tengo q llamar al de incrementar con los que dio verdadero e
                                    //infomar que no se realizaron modificaciones por error en la db . con try catch

                                    var elemento = Resultados.Find(x => x.IdComponente == ComponenteActualizar.Id);
                                    elemento.resultado = new Stocks().ActualizarStockInsumo(null, ComponenteActualizar);

                                }
                                else if (Componente.Peso != null)
                                {
                                    ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                    {
                                        Id = Componente.IdInsumo,
                                        Valor = Componente.Cantidad
                                    };

                                    var elemento = Resultados.Find(x => x.IdComponente == ComponenteActualizar.Id);
                                    elemento.resultado = new Stocks().ActualizarStockInsumo(null, ComponenteActualizar);


                                }
                                else if (Componente.Cantidad != null)
                                {
                                    ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                    {
                                        Id = Componente.IdInsumo,
                                        Valor = Componente.Cantidad
                                    };

                                    var elemento = Resultados.Find(x => x.IdComponente == ComponenteActualizar.Id);
                                    elemento.resultado = new Stocks().ActualizarStockInsumo(null, ComponenteActualizar);
                                }
                            }
                        }

                        bool ResultadosOK = Resultados.Exists(x => x.resultado == false);

                        if (ResultadosOK)
                        {

                            Resultados.ForEach(elemento => elemento.resultado = null);

                            while (Resultados.Exists(x => x.resultado == false) == true)
                            {
                                foreach (var elemento in Resultados)
                                {
                                    ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                    {
                                        Id = elemento.IdComponente,
                                        Valor = elemento.ValorAnterior,
                                    };

                                    var _elemento = Resultados.Find(x => x.IdComponente == ComponenteActualizar.Id);

                                    //
                                   

                                    //Continuar aca
                                    _elemento.resultado = new Stocks().ActualizarStockInsumo(null,ComponenteActualizar);
                                }
                            }

                            var Resultado = new ObjectResult("Error interno, no se aplicaron los cambios")
                            {
                                StatusCode = 500,
                            };
                            return Resultado;

                        }
                        else
                        {
                            if (new Stocks().IncrementarStockProducto(Actualizacion))
                            {
                                return new StatusCodeResult(200);
                            }
                            else
                            {
                                bool resultado = false;
                                int i = 0;
                                while (resultado==false && i>250)
                                {
                                    resultado = new Stocks().IncrementarStockProducto(Actualizacion);
                                    i++;
                                }

                                if (resultado==false && i<=250)
                                {
                                    var Resultado = new ObjectResult("Error interno, no se aplicaron los cambios")
                                    {
                                        StatusCode = 500,
                                    };
                                    return Resultado;

                                }
                                else
                                {
                                    return new StatusCodeResult(200);
                                }
                            }
                             
                           
                        }
                    }

                case "-":
                    if (new Stocks().DisminuirStockProducto(Actualizacion))
                    {
                        return new StatusCodeResult(200);
                    }
                    else
                    {
                        bool resultado = false;
                        int i = 0;
                        while (resultado == false && i > 250)
                        {
                            resultado = new Stocks().DisminuirStockProducto(Actualizacion);
                            i++;
                        }

                        if (resultado == false && i <= 250)
                        {
                            var Resultado = new ObjectResult("Error interno, no se aplicaron los cambios")
                            {
                                StatusCode = 500,
                            };
                            return Resultado;

                        }
                        else
                        {
                            return new StatusCodeResult(200);
                        }
                    }


                case "=":
                    if (new Stocks().SetCantidadProducto(Actualizacion))
                    {
                        return new StatusCodeResult(200);
                    }
                    else
                    {
                        bool resultado = false;
                        int i = 0;
                        while (resultado == false && i > 250)
                        {
                            resultado = new Stocks().SetCantidadProducto(Actualizacion);
                            i++;
                        }

                        if (resultado == false && i <= 250)
                        {
                            var Resultado = new ObjectResult("Error interno, no se aplicaron los cambios")
                            {
                                StatusCode = 500,
                            };
                            return Resultado;

                        }
                        else
                        {
                            return new StatusCodeResult(200);
                        }
                    }


                default:

                    var ResultadoDefault = new ObjectResult("Error interno, no se aplicaron los cambios")
                    {
                        StatusCode = 500,
                    };
                    return ResultadoDefault;

            }
        }


        public  static class Productos
        {
            internal static async Task<IActionResult> Actualizar(DTOStockProductos DTOStockProducto)
            {
                try
                {
                    Producto StockProductoDB = new Producto();
                    PropertyInfo[] PropsDTOStockProducto = DTOStockProducto.GetType().GetProperties(); //Valores que recibo                    
                    PropertyInfo[] PropsObjStockInsumosDB = StockProductoDB.GetType().GetProperties(); //Objeto para la Base de Datos

                    foreach (var PropDTO in PropsDTOStockProducto)
                        foreach (var PropObjDB in PropsObjStockInsumosDB)
                            if (PropObjDB.Name.ToLower().Contains(PropDTO.Name.ToLower()) && PropDTO.GetValue(DTOStockProducto) != null)
                                PropObjDB.SetValue(StockProductoDB, PropDTO.GetValue(DTOStockProducto));

                    bool Resultado = await new Stocks.Productos().Actualizar(StockProductoDB);

                    if (Resultado)
                        return new StatusCodeResult(200);
                    else
                        return new ContentResult()
                        {
                            Content = "No se aplicaron los cambios",
                            ContentType = "application/json",
                            StatusCode = 400
                        };
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

            public static class Insumos
            {
                internal static async Task<IActionResult> Actualizar(DTOStock DtoStockInsumo)
                {

                    try
                    {
                        StockInsumos ObjStockInsumosDB = new StockInsumos();
                        PropertyInfo[] PropsDTOStockInsumo = DtoStockInsumo.GetType().GetProperties(); //Valores que recibo                    
                        PropertyInfo[] PropsObjStockInsumosDB = ObjStockInsumosDB.GetType().GetProperties(); //Objeto para la Base de Datos

                        foreach (var PropDTO in PropsDTOStockInsumo)
                            foreach (var PropObjDB in PropsObjStockInsumosDB)
                                if (PropObjDB.Name.ToLower().Contains(PropDTO.Name.ToLower()) && PropDTO.GetValue(DtoStockInsumo) != null)
                                    PropObjDB.SetValue(ObjStockInsumosDB, PropDTO.GetValue(DtoStockInsumo));

                        bool Resultado = await new Stocks.Insumos().Actualizar(ObjStockInsumosDB);

                        if (Resultado)
                            return new StatusCodeResult(200);   
                        else
                            return new ContentResult()
                            {
                                Content="No se aplicaron los cambios",
                                ContentType="application/json",
                                StatusCode=400
                            };
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
        }

    }




}
