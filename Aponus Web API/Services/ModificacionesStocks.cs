using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Mapping;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Aponus_Web_API.Services
{
    public class ModificacionesStocks : OperacionesStocks
    {
      
        internal void ActualizarInsumo_Aumentar(ActualizarStock Actualizacion)
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
                        case"Recibido":
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
        internal void ActualizarInsumo_Descontar(ActualizarStock Actualizacion)
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



        internal void ActualizarInsumo_NuevoValor(ActualizarStock actualizacion)
        {
            switch (actualizacion.Operador)
            {
                case "=":
                    
                default:
                    break;
            }
        }

        internal void ActualizarProducto(ActualizarStock actualizacion)
        {
            throw new NotImplementedException();
        }

    }




}
