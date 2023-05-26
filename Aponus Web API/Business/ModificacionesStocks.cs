using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        internal void newActualizarInsumo_Aumentar(ActualizacionStock Actualizacion)
        {
            switch (Actualizacion.Destino)
            {
                case "Recibido":
                    IncrementarRecibidos(Actualizacion);

                    switch (Actualizacion.Origen)
                    {
                        case "Granallado":
                            NewDescontarGranallado(Actualizacion);
                            break;
                        case "Pintura":
                            NewDescontarPintura(Actualizacion);
                            break;
                        case "Proceso":
                            NewDescontarProceso(Actualizacion);
                            break;
                        case "Moldeado":
                            NewDescontarMoldeado(Actualizacion);
                            break;

                        default:
                            break;
                    }
                    break;

                case "Granallado":
                    NewIncrementarGranallado(Actualizacion);
                    switch (Actualizacion.Origen)
                    {
                        case "Recibido":
                            NewDescontarRecibidos(Actualizacion);
                            break;
                        case "Pitnura":
                            NewDescontarPintura(Actualizacion);
                            break;
                        case "Proceso":
                            NewDescontarProceso(Actualizacion);
                            break;
                        case "Moleado":
                            NewDescontarMoldeado(Actualizacion);
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
                            NewDescontarRecibidos(Actualizacion);
                            break;
                        case "Granallado":
                            NewDescontarGranallado(Actualizacion);
                            break;
                        case "Proceso":
                            NewDescontarProceso(Actualizacion);
                            break;
                        case "Moldeado":
                            NewDescontarMoldeado(Actualizacion);
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
                            NewDescontarRecibidos(Actualizacion);
                            break;
                        case "Granallado":
                            NewDescontarGranallado(Actualizacion);
                            break;
                        case "Pintura":
                            NewDescontarPintura(Actualizacion);
                            break;
                        case "Moldeado":
                            NewDescontarMoldeado(Actualizacion);
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
                            NewDescontarRecibidos(Actualizacion);
                            break;
                        case "Granallado":
                            NewDescontarGranallado(Actualizacion);
                            break;
                        case "Proceso":
                            NewDescontarProceso(Actualizacion);
                            break;
                        case "Pintura":
                            NewDescontarPintura(Actualizacion);
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

        private void NewIncrementarGranallado(ActualizacionStock actualizacion)
        {
            throw new NotImplementedException();
        }

        private void NewDescontarRecibidos(ActualizacionStock actualizacion)
        {
            throw new NotImplementedException();
        }

        private void NewDescontarMoldeado(ActualizacionStock actualizacion)
        {
            throw new NotImplementedException();
        }

        private void NewDescontarProceso(ActualizacionStock actualizacion)
        {
            throw new NotImplementedException();
        }

        private void NewDescontarPintura(ActualizacionStock actualizacion)
        {
            throw new NotImplementedException();
        }

        private void NewDescontarGranallado(ActualizacionStock actualizacion)
        {
            throw new NotImplementedException();
        }

        internal void NewActualizarInsumo_Descontar(ActualizacionStock actualizacion)
        {
            throw new NotImplementedException();
        }

        internal void NewActualizarInsumo_NuevoValor(ActualizacionStock actualizacion)
        {
            throw new NotImplementedException();
        }
    }




}
