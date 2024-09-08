using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Acceso_a_Datos.Entidades;
using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Z.EntityFramework.Plus;
using Aponus_Web_API.Support;

namespace Aponus_Web_API.Business
{
    public class ModificacionesStocks : Stocks
    { 
       

        
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

        internal IActionResult newActualizarStockInsumo(DTOMovimientosStock Movimiento)
        {

            List<ActualizacionStock> ListaSuministros = new List<ActualizacionStock>();
            Stocks stocks = new Stocks();

            foreach (DTOSuministrosMovimientosStock suministro in Movimiento.Suministros)
            {
                decimal valorNuevoOrigen = (suministro.ValorAnteriorOrigen != null ? Convert.ToDecimal(suministro.ValorAnteriorOrigen) : 0) - Convert.ToDecimal(suministro.Cantidad);
                decimal valorNuevoDestino= (suministro.ValorAnteriorDestino!= null ? Convert.ToDecimal(suministro.ValorAnteriorOrigen) : 0) + Convert.ToDecimal(suministro.Cantidad);


                if(valorNuevoOrigen < 0)
                    return new ContentResult()
                    {
                        Content = $"La cantidad en del Suministro Id:{suministro.IdSuministro} Disponible en " +
                                    $"{Movimiento.Origen} es inferior a la cantidad en {Movimiento.Destino}",
                        ContentType = "Aplication/Json",
                        StatusCode = 400,
                    };

                suministro.ValorNuevoOrigen = valorNuevoOrigen.ToString();
                suministro.ValorNuevoDestino = valorNuevoDestino.ToString();

                ListaSuministros.Add(new ActualizacionStock()
                {
                    Id = suministro.IdSuministro,
                    Origen = Movimiento.Origen,
                    Destino = Movimiento.Destino,
                    Valor = Convert.ToDecimal(suministro.Cantidad)

                });
                
            }

            using (AponusContext AponusDbContext = new AponusContext())
            {
                using (var transaccion = AponusDbContext.Database.BeginTransaction())
                {
                    bool Rollback = false;

                    foreach (ActualizacionStock suministro in ListaSuministros)
                    {
                        if (!stocks.IncrementarStockInsumo(AponusDbContext, suministro, suministro.Destino.ToUpper()))
                        {
                            Rollback = true;
                        }

                        if (!Rollback && !stocks.DescontarStockInsumo(AponusDbContext, suministro, suministro.Origen.ToUpper()))
                        {
                            Rollback = true;
                        }

                    }
                    int? IdMovimiento = stocks.GuardarDatosMovimiento(AponusDbContext, new Stock_Movimientos
                    {
                        CreadoUsuario = Movimiento.UsuarioCreacion,
                        ModificadoUsuario = Movimiento.UsuarioModificacion,
                        FechaHoraCreado = Fechas.ObtenerFechaHora(),
                        IdProveedorOrigen = (int)Movimiento.IdProveedorOrigen,
                        IdProveedorDestino = (int)Movimiento.IdProveedorDestino,
                    });

                    if (IdMovimiento == null) Rollback = true;

                    List<SuministrosMovimientosStock> Suministros = Movimiento.Suministros
                        .Select(x => new SuministrosMovimientosStock()
                        {
                            IdMovimiento = (int)IdMovimiento,
                            Cantidad = Convert.ToDecimal(x.Cantidad),
                            IdSuministro = x.IdSuministro,
                            ValorAnteriorOrigen = Convert.ToDecimal(x.ValorAnteriorOrigen),
                            ValorAnteriorDestino = Convert.ToDecimal(x.ValorAnteriorDestino),
                            ValorNuevoOrigen = Convert.ToDecimal(x.ValorNuevoOrigen),
                            ValorNuevoDestino = Convert.ToDecimal(x.ValorNuevoDestino)

                        })
                        .ToList();

                    if (!stocks.GuardarSuministrosMovimiento(AponusDbContext, Suministros)) Rollback = true;

                    //Obtener el Nombre del Proveedor de Destino
                    IActionResult Proveedores =  BS_Entidades.Listar(Movimiento.IdProveedorDestino ?? 0, 0, 0);
                    DTOEntidades? proveedor = new DTOEntidades();

                    if (Proveedores is JsonResult jsonProveedores && jsonProveedores.Value!=null && jsonProveedores.Value is IEnumerable<DTOEntidades> ProveedoresList)
                    {
                        proveedor = ProveedoresList.FirstOrDefault(x => x.IdEntidad == Movimiento.IdProveedorDestino);
                        
                    }

                    string? NombreCompletoProveedor = proveedor.Apellido + " " + proveedor.Nombre;//ListaProveedores.Where(x => x.IdProveedor == Movimiento.IdProveedorDestino).Select(x => x.Apellido + " " + x.Nombre).FirstOrDefault();
                    string? NombreClave = proveedor.NombreClave; //ListaProveedores.Where(x => x.IdProveedor == Movimiento.IdProveedorDestino).Select(x => x.NombreClave).FirstOrDefault();
                    //Obtener el Nombre del Proveedor de Destino

                    string Ruta = stocks.CrearDirectorioMovimientos(string.IsNullOrEmpty(NombreClave) ? NombreCompletoProveedor : NombreClave);

                    List<ArchivosMovimientosStock> DatosArchivosMovimiento = stocks.CopiarArchivosMovimientos(Movimiento.Archivos, Ruta);

                    if (DatosArchivosMovimiento.Count == 0) Rollback = true;

                    DatosArchivosMovimiento.ForEach(x => x.IdMovimiento = (int)IdMovimiento);

                    if (!stocks.GuardarDatosArchivosMovimiento(AponusDbContext,DatosArchivosMovimiento)) Rollback = true;
                    if (new MovimientosStock().RegistrarModificacion(AponusDbContext, Movimiento)) Rollback = true;

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
                        List<NewStocks> ComponentesList = DetallesComponentesProducto.StockComponente;                        

                        foreach (NewStocks Componente in ComponentesList)
                        {

                            if (Componente.LongReq != null)
                            {
                                ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                {
                                    Id = Componente.IdInsumo,
                                    Valor = Componente.LongReq
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
                            else if (Componente.PesoReq != null)
                            {
                                ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                {
                                    Id = Componente.IdInsumo,
                                    Valor = Componente.PesoReq
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
                            else if (Componente.CantidadReq != null)
                            {
                                ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                {
                                    Id = Componente.IdInsumo,
                                    Valor = Componente.CantidadReq
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
                            List<NewStocks> ComponentesList = DetallesComponentesProducto.StockComponente;

                            foreach (NewStocks Componente in ComponentesList)
                            {
                                if (Componente.LongReq != null)
                                {
                                    ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                    {
                                        Id = Componente.IdInsumo,
                                        Valor = Componente.LongReq
                                    };
                                    //Guardart los ccomponentes, valores y bool del resutado de descontar enu una lista para 
                                    //verificar si alguno dio falso y si dio falso, tengo q llamar al de incrementar con los que dio verdadero e
                                    //infomar que no se realizaron modificaciones por error en la db . con try catch

                                    var elemento = Resultados.Find(x => x.IdComponente == ComponenteActualizar.Id);
                                    elemento.resultado = new Stocks().DescontarStockInsumo(null, ComponenteActualizar, "Proceso");

                                }
                                else if (Componente.PesoReq != null)
                                {
                                    ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                    {
                                        Id = Componente.IdInsumo,
                                        Valor = Componente.CantidadReq
                                    };

                                    var elemento = Resultados.Find(x => x.IdComponente == ComponenteActualizar.Id);
                                    elemento.resultado = new Stocks().DescontarStockInsumo(null, ComponenteActualizar, "Proceso");


                                }
                                else if (Componente.CantidadReq != null)
                                {
                                    ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                    {
                                        Id = Componente.IdInsumo,
                                        Valor = Componente.CantidadReq
                                    };

                                    var elemento = Resultados.Find(x => x.IdComponente == ComponenteActualizar.Id);
                                    elemento.resultado = new Stocks().DescontarStockInsumo(null, ComponenteActualizar, "Proceso");
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
                                    _elemento.resultado = new Stocks().IncrementarStockInsumo(null,ComponenteActualizar, "Proceso");
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




    }




}
