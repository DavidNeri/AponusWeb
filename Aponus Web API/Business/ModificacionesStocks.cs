using Aponus_Web_API.Acceso_a_Datos.Componentes;
using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Drawing;
using System.Reflection;

namespace Aponus_Web_API.Business
{
    public class ModificacionesStocks : OperacionesStocks
    {

        internal void ActualizarInsumo_Aumentar(ActualizacionStock Actualizacion)
        {
            switch (Actualizacion.Destino)
            {
                case "Recibido":
                    IncrementarRecibidos(Actualizacion);

                    switch (Actualizacion.Origen)
                    {
                        case "Granallado":
                            DescontarGranallado(Actualizacion);
                            break;
                        case "Pintura":
                            DescontarPintura(Actualizacion);
                            break;
                        case "Proceso":
                            DescontarProceso(Actualizacion);
                            break;
                        case "Moldeado":
                            DescontarMoldeado(Actualizacion);
                            break;

                        default:
                            break;
                    }
                    break;

                case "Granallado":
                    IncrementarGranallado(Actualizacion);
                    switch (Actualizacion.Origen)
                    {
                        case "Recibido":
                            DescontarRecibidos(Actualizacion);
                            break;
                        case "Pitnura":
                            DescontarPintura(Actualizacion);
                            break;
                        case "Proceso":
                            DescontarProceso(Actualizacion);
                            break;
                        case "Moleado":
                            DescontarMoldeado(Actualizacion);
                            break;

                        default:
                            break;
                    }
                    break;

                case "Pintura":
                    IncrementarPintura(Actualizacion);
                    switch (Actualizacion.Origen)
                    {
                        case "Recibido":
                            DescontarRecibidos(Actualizacion);
                            break;
                        case "Granallado":
                            DescontarGranallado(Actualizacion);
                            break;
                        case "Proceso":
                            DescontarProceso(Actualizacion);
                            break;
                        case "Moldeado":
                            DescontarMoldeado(Actualizacion);
                            break;

                        default:
                            break;
                    }
                    break;

                case "Proceso":
                    IncrementarProceso(Actualizacion);

                    switch (Actualizacion.Origen)
                    {
                        case "Recibido":
                            DescontarRecibidos(Actualizacion);
                            break;
                        case "Granallado":
                            DescontarGranallado(Actualizacion);
                            break;
                        case "Pintura":
                            DescontarPintura(Actualizacion);
                            break;
                        case "Moldeado":
                            DescontarMoldeado(Actualizacion);
                            break;

                        default:
                            break;
                    }
                    break;

                case "Moldeado":
                    IncrementarMoldeado(Actualizacion);

                    switch (Actualizacion.Origen)
                    {
                        case "Recibido":
                            DescontarRecibidos(Actualizacion);
                            break;
                        case "Granallado":
                            DescontarGranallado(Actualizacion);
                            break;
                        case "Proceso":
                            DescontarProceso(Actualizacion);
                            break;
                        case "Pintura":
                            DescontarPintura(Actualizacion);
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }

        }
        internal void ActualizarInsumo_Descontar(ActualizacionStock Actualizacion)
        {
            switch (Actualizacion.Destino)
            {
                case "Recibido":
                    DescontarRecibidos(Actualizacion);

                    switch (Actualizacion.Origen)
                    {
                        case "Granallado":
                            IncrementarGranallado(Actualizacion);
                            break;
                        case "Pintura":
                            IncrementarPintura(Actualizacion);
                            break;
                        case "Proceso":
                            IncrementarProceso(Actualizacion);
                            break;
                        case "Moldeado":
                            IncrementarMoldeado(Actualizacion);
                            break;

                        default:
                            break;
                    }
                    break;

                case "Granallado":
                    DescontarGranallado(Actualizacion);

                    switch (Actualizacion.Origen)
                    {
                        case "Recibido":
                            IncrementarRecibidos(Actualizacion);
                            break;

                        case "Pintura":
                            IncrementarPintura(Actualizacion);
                            break;

                        case "Proceso":
                            IncrementarProceso(Actualizacion);
                            break;

                        case "Moldeado":
                            IncrementarMoldeado(Actualizacion);
                            break;

                        default:
                            break;
                    }
                    break;

                case "Pintura":
                    DescontarPintura(Actualizacion);
                    switch (Actualizacion.Origen)
                    {
                        case "Recibido":
                            IncrementarRecibidos(Actualizacion);
                            break;

                        case "Granallado":
                            IncrementarGranallado(Actualizacion);
                            break;
                        case "Proceso":
                            IncrementarProceso(Actualizacion);
                            break;
                        case "Moldeado":
                            IncrementarMoldeado(Actualizacion);
                            break;

                        default:
                            break;
                    }
                    break;

                case "Proceso":

                    DescontarProceso(Actualizacion);
                    switch (Actualizacion.Origen)
                    {
                        case "Recibido":
                            IncrementarRecibidos(Actualizacion);
                            break;

                        case "Granallado":
                            IncrementarGranallado(Actualizacion);
                            break;
                        case "Pintura":
                            IncrementarPintura(Actualizacion);
                            break;
                        case "Moldeado":
                            IncrementarMoldeado(Actualizacion);
                            break;

                        default:
                            break;
                    }
                    break;

                case "Moldeado":

                    DescontarMoldeado(Actualizacion);
                    switch (Actualizacion.Origen)
                    {
                        default:
                            break;
                    }

                    if (Actualizacion.Origen == "Recibido")
                    {
                        IncrementarRecibidos(Actualizacion);
                    }
                    else if (Actualizacion.Origen == "Granallado")
                    {
                        IncrementarGranallado(Actualizacion);
                    }
                    else if (Actualizacion.Origen == "Pintura")
                    {
                        IncrementarPintura(Actualizacion);
                    }
                    else if (Actualizacion.Origen == "Proceso")
                    {
                        IncrementarProceso(Actualizacion);
                    }
                    break;

                default:
                    break;
            }

        }

        internal void ActualizarInsumo_NuevoValor(ActualizacionStock Actualizacion)
        {
            switch (Actualizacion.Destino)
            {
                case "Recibido":
                    SetRecibidos(Actualizacion);
                    break;
                case "Granallado":
                    SetGranallado(Actualizacion);
                    break;
                case "Pintura":
                    SetPintura(Actualizacion);
                    break;
                case "Proceso":
                    SetProceso(Actualizacion);
                    break;
                case "Moldeado":
                    SetMoldeado(Actualizacion);
                    break;

                default:
                    break;
            }
        }

        
        internal void ActualizarProducto_Agregar(ActualizacionStock Actualizacion)
        {
            try
            {
                new OperacionesStocks().ObtenerComponentes(Actualizacion);
                new OperacionesStocks().AgregarProducto(Actualizacion);
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

                DBContext.stockInsumos.Select(x=>x.CantidadGranallado);

                new OperacionesStocks().RestarProducto(Actualizacion);
            }
            catch (Exception)
            {


            }

        }

        internal void ActualizarProducto_NuevoValor(ActualizacionStock Actualizacion)
        {
            try
            {
                new OperacionesStocks().SetCantidadProducto(Actualizacion);
            }
            catch (Exception)
            {


            }

        }

        internal IActionResult newActualizarStockInsumo(ActualizacionStock Actualizacion)
        {
            StockInsumos? stockInsumo = new OperacionesStocks().BuscarInsumo(Actualizacion.Id);
            PropertyInfo[] propiedades = stockInsumo.GetType().GetProperties();
            decimal? valorOrigen=null;
            Actualizacion.Valor = Actualizacion.Valor ?? 0;
            PropertyInfo? propiedadOrigen = null;


            if (string.IsNullOrEmpty(Actualizacion.Destino))
            {
                var Resultado = new ObjectResult("Ingresar el Destino")
                {
                    StatusCode = 500,
                };
                return Resultado;
            }
            else
            {
                if (Actualizacion.Origen != null)
                {
                    propiedadOrigen = propiedades.FirstOrDefault(p => p.Name.Contains(Actualizacion.Origen));
                    object valor = propiedadOrigen.GetValue(stockInsumo);
                    valorOrigen = (decimal?)valor ?? 0;
                }


                if (propiedadOrigen != null || Actualizacion.Origen == null)
                {
                    if (propiedadOrigen != null)
                    {

                        if ((valorOrigen < Actualizacion.Valor) & valorOrigen != null)
                        {
                            var Resultado = new ObjectResult("La cantidad a agregar o restar en el Origen es inferior a la que se desea incrementar o descontar en el destino")
                            {
                                StatusCode = 500,
                            };
                            return Resultado;
                        }
                    }
                    if (Actualizacion.Origen == null || ((valorOrigen > Actualizacion.Valor) & (valorOrigen != null || propiedadOrigen == null)))
                    {
                        switch (Actualizacion.Operador)
                        {
                            case "+": //HAce la misma validacion q para restar

                                if ((propiedadOrigen == null || Actualizacion.Origen != null) && Actualizacion.Destino != null)
                                {
                                    if (propiedadOrigen == null)
                                    {
                                        PropertyInfo? ValorDestinoDB = propiedades.FirstOrDefault(p => p.Name.Contains(Actualizacion.Destino));
                                        object valor = ValorDestinoDB.GetValue(stockInsumo);
                                        decimal? ValorDestinoDBDec = (decimal?)valor;


                                        /* if ((ValorDestinoDBDec - Actualizacion.Valor) < 0)
                                         {

                                             var Resultado = new ObjectResult("El valor a restar es inferior al disponible")
                                             {
                                                 StatusCode = 500,
                                             };
                                             return Resultado;
                                         }
                                        */
                                    }

                                    if (Actualizacion.Origen != null)
                                    {
                                        PropertyInfo? ValorOrigenDB = propiedades.FirstOrDefault(p => p.Name.Contains(Actualizacion.Origen));
                                        object valor = ValorOrigenDB.GetValue(stockInsumo);
                                        decimal? ValorOrigenDBDec = (decimal?)valor;
                                        if (ValorOrigenDBDec - Actualizacion.Valor < 0)
                                        {

                                            var Resultado = new ObjectResult("El valor a restar en el 'Destino' es inferior al disponible en el 'Origen'")
                                            {
                                                StatusCode = 500,
                                            };
                                            return Resultado;
                                        }
                                    }
                                }


                                if (new OperacionesStocks().IncrementarStockInsumo(Actualizacion, Actualizacion.Destino))
                                {

                                    if (Actualizacion.Origen != null)
                                    {
                                        if (new OperacionesStocks().DescontarStockInsumo(Actualizacion, Actualizacion.Origen) == false)
                                        {
                                            new OperacionesStocks().DescontarStockInsumo(Actualizacion, Actualizacion.Destino);

                                            var Resultado = new ObjectResult("Error interno, no se aplicaron los cambios")
                                            {
                                                StatusCode = 500,
                                            };
                                            return Resultado;
                                        }
                                    }
                                }
                                else
                                {
                                    var Resultado = new ObjectResult("Error interno, no se aplicaron los cambios")
                                    {
                                        StatusCode = 500,
                                    };
                                    return Resultado;

                                }
                                break;
                            case "-":

                                if ((propiedadOrigen == null || Actualizacion.Origen != null) && Actualizacion.Destino != null)
                                {

                                    if (propiedadOrigen == null)
                                    {
                                        PropertyInfo? ValorDestinoDB = propiedades.FirstOrDefault(p => p.Name.Contains(Actualizacion.Destino));
                                        object valor = ValorDestinoDB.GetValue(stockInsumo);
                                        decimal? ValorDestinoDBDec = (decimal?)valor;
                                        if (ValorDestinoDBDec - Actualizacion.Valor < 0)
                                        {

                                            var Resultado = new ObjectResult("El valor a restar es inferior al disponible")
                                            {
                                                StatusCode = 500,
                                            };
                                            return Resultado;
                                        }
                                    }

                                    if (Actualizacion.Origen != null)
                                    {
                                        PropertyInfo? ValorOrigenDB = propiedades.FirstOrDefault(p => p.Name.Contains(Actualizacion.Origen));
                                        object valor = ValorOrigenDB.GetValue(stockInsumo);
                                        decimal? ValorOrigenDBDec = (decimal?)valor;
                                        if (ValorOrigenDBDec - Actualizacion.Valor < 0)
                                        {

                                            var Resultado = new ObjectResult("El valor a restar en el 'Destino' es inferior al disponible en el 'Origen'")
                                            {
                                                StatusCode = 500,
                                            };
                                            return Resultado;
                                        }
                                    }


                                    if (new OperacionesStocks().DescontarStockInsumo(Actualizacion, Actualizacion.Destino))
                                    {
                                        if (Actualizacion.Origen != null)
                                        {
                                            if (new OperacionesStocks().IncrementarStockInsumo(Actualizacion, Actualizacion.Origen) == false)
                                            {
                                                new OperacionesStocks().IncrementarStockInsumo(Actualizacion, Actualizacion.Destino);
                                                var Resultado = new ObjectResult("Error interno, no se aplicaron los cambios")
                                                {
                                                    StatusCode = 500,
                                                };
                                                return Resultado;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        var Resultado = new ObjectResult("Error interno, no se aplicaron los cambios")
                                        {
                                            StatusCode = 500,
                                        };
                                        return Resultado;
                                    }
                                }

                                break;
                            case "=":
                                if (new OperacionesStocks().NewSetearStockInsumo(Actualizacion))
                                {
                                    return new StatusCodeResult(200);
                                }
                                else
                                {
                                    var Resultado = new ObjectResult("Error interno, no se aplicaron los cambios")
                                    {
                                        StatusCode = 500,
                                    };
                                    return Resultado;
                                }

                            default:
                                return new StatusCodeResult(500);

                        }
                    }

                    return new StatusCodeResult(200);
                }
                else
                {
                    var Resultado = new ObjectResult("Error interno, no se aplicaron los cambios")
                    {
                        StatusCode = 500,
                    };
                    return Resultado;
                }
            }
            
        }

        internal IActionResult newActualizarStockProducto(ActualizacionStock Actualizacion)
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

                                StockInsumos? StockComponente = new OperacionesStocks().BuscarInsumo(Componente.IdInsumo);
                                Resultados.Add((StockComponente.IdInsumo, null, StockComponente.CantidadProceso, ComponenteActualizar.Valor));

                                if (StockComponente.CantidadProceso != null & ComponenteActualizar.Valor != null)
                                {
                                    if ((int?)StockComponente.CantidadProceso < (int?)ComponenteActualizar.Valor)
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

                                StockInsumos? StockComponente = new OperacionesStocks().BuscarInsumo(Componente.IdInsumo);
                                Resultados.Add((StockComponente.IdInsumo, null, StockComponente.CantidadProceso, ComponenteActualizar.Valor));

                                if (StockComponente.CantidadProceso != null & ComponenteActualizar.Valor != null)
                                {
                                    if (StockComponente.CantidadProceso < ComponenteActualizar.Valor)
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

                                StockInsumos? StockComponente = new OperacionesStocks().BuscarInsumo(Componente.IdInsumo);
                                Resultados.Add((StockComponente.IdInsumo, null, StockComponente.CantidadProceso, ComponenteActualizar.Valor));

                                if (StockComponente.CantidadProceso != null & ComponenteActualizar.Valor != null)
                                {
                                    if (StockComponente.CantidadProceso < ComponenteActualizar.Valor)
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
                                    elemento.resultado = new OperacionesStocks().DescontarStockInsumo(ComponenteActualizar, "Proceso");

                                }
                                else if (Componente.PesoReq != null)
                                {
                                    ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                    {
                                        Id = Componente.IdInsumo,
                                        Valor = Componente.CantidadReq
                                    };

                                    var elemento = Resultados.Find(x => x.IdComponente == ComponenteActualizar.Id);
                                    elemento.resultado = new OperacionesStocks().DescontarStockInsumo(ComponenteActualizar, "Proceso");


                                }
                                else if (Componente.CantidadReq != null)
                                {
                                    ActualizacionStock ComponenteActualizar = new ActualizacionStock()
                                    {
                                        Id = Componente.IdInsumo,
                                        Valor = Componente.CantidadReq
                                    };

                                    var elemento = Resultados.Find(x => x.IdComponente == ComponenteActualizar.Id);
                                    elemento.resultado = new OperacionesStocks().DescontarStockInsumo(ComponenteActualizar, "Proceso");
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
                                    _elemento.resultado = new OperacionesStocks().IncrementarStockInsumo(ComponenteActualizar, "Proceso");
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
                            if (new OperacionesStocks().AgregarProducto(Actualizacion))
                            {
                                return new StatusCodeResult(200);
                            }
                            else
                            {
                                bool resultado = false;
                                int i = 0;
                                while (resultado==false && i>250)
                                {
                                    resultado = new OperacionesStocks().AgregarProducto(Actualizacion);
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
                    if (new OperacionesStocks().RestarProducto(Actualizacion))
                    {
                        return new StatusCodeResult(200);
                    }
                    else
                    {
                        bool resultado = false;
                        int i = 0;
                        while (resultado == false && i > 250)
                        {
                            resultado = new OperacionesStocks().RestarProducto(Actualizacion);
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
                    if (new OperacionesStocks().SetCantidadProducto(Actualizacion))
                    {
                        return new StatusCodeResult(200);
                    }
                    else
                    {
                        bool resultado = false;
                        int i = 0;
                        while (resultado == false && i > 250)
                        {
                            resultado = new OperacionesStocks().SetCantidadProducto(Actualizacion);
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
