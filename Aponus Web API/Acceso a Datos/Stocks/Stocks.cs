using Aponus_Web_API.Acceso_a_Datos.Insumos;
using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NtpClient;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Aponus_Web_API.Acceso_a_Datos.Stocks
{
    public class Stocks
    {
        private readonly AponusContext AponusDBContext;
        public Stocks() { AponusDBContext = new AponusContext(); }
        int? ValorAnteriorInt=null;
        decimal? ValorAnteriorDec=null;

       //Incrementar
        internal void IncrementarRecibidos(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;
            ValorAnteriorDec = null;

            //Pesables
            ValorAnteriorDec = AponusDBContext.StockPesables
              .Where(x => x.IdComponente == Actualizacion.IdExistencia)
              .Select(x => x.CantidadRecibido)
              .SingleOrDefault();

            if (ValorAnteriorDec != null)
            {
                AponusDBContext.StockPesables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadRecibido, ValorAnteriorDec + Convert.ToDecimal(Actualizacion.Valor)));
                ValorAnteriorDec = null;
            }

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadRecibido)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadRecibido, ValorAnteriorInt + Actualizacion.Valor));
                ValorAnteriorInt = null;
            }

            //Mensurables
            ValorAnteriorInt = AponusDBContext.StockMensurables
                .Where(x => x.IdComponente == Actualizacion.IdExistencia)
                .Select(x => x.CantidadRecibido)
                .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockMensurables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadRecibido, ValorAnteriorInt + Actualizacion.Valor));
                ValorAnteriorInt = null;
            }
        }

        internal void IncrementarGranallado(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadGranallado)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadGranallado, ValorAnteriorInt + Actualizacion.Valor));
                ValorAnteriorInt = null;

            }

        }
        internal void IncrementarPintura(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;
            ValorAnteriorDec = null;

            //Pesables
            ValorAnteriorDec = AponusDBContext.StockPesables
              .Where(x => x.IdComponente == Actualizacion.IdExistencia)
              .Select(x => x.CantidadPintura)
              .SingleOrDefault();

            if (ValorAnteriorDec != null)
            {
                AponusDBContext.StockPesables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadPintura, ValorAnteriorDec + Convert.ToDecimal(Actualizacion.Valor)));
                ValorAnteriorDec = null;
            }

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadPintura)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadPintura, ValorAnteriorInt + Actualizacion.Valor));
                ValorAnteriorInt = null;
            }

        }

        internal void IncrementarProceso(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;
            ValorAnteriorDec = null;

            //Pesables
            ValorAnteriorDec = AponusDBContext.StockPesables
              .Where(x => x.IdComponente == Actualizacion.IdExistencia)
              .Select(x => x.CantidadProceso)
              .SingleOrDefault();

            if (ValorAnteriorDec != null)
            {
                AponusDBContext.StockPesables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso, ValorAnteriorDec + Convert.ToDecimal(Actualizacion.Valor)));
                ValorAnteriorDec = null;
            }

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadProceso)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso, ValorAnteriorInt + Actualizacion.Valor));
                ValorAnteriorInt = null;
            }

            //Mensurables
            ValorAnteriorInt = AponusDBContext.StockMensurables
                .Where(x => x.IdComponente == Actualizacion.IdExistencia)
                .Select(x => x.CantidadProceso)
                .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockMensurables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso, ValorAnteriorInt + Actualizacion.Valor));
                ValorAnteriorInt = null;
            }
        }

        internal void IncrementarMoldeado(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;
            ValorAnteriorDec = null;

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadMoldeado)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadMoldeado, ValorAnteriorInt + Actualizacion.Valor));
                ValorAnteriorInt = null;
            }


        }
        //-----------Descontar-------
        internal void DescontarRecibidos(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;
            ValorAnteriorDec = null;

            //Pesables
            ValorAnteriorDec = AponusDBContext.StockPesables
              .Where(x => x.IdComponente == Actualizacion.IdExistencia)
              .Select(x => x.CantidadRecibido)
              .SingleOrDefault();

            if (ValorAnteriorDec != null)
            {
                AponusDBContext.StockPesables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadRecibido, ValorAnteriorDec - Convert.ToDecimal(Actualizacion.Valor)));
                ValorAnteriorDec = null;
            }

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadRecibido)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadRecibido, ValorAnteriorInt - Actualizacion.Valor));
                ValorAnteriorInt = null;
            }

            //Mensurables
            ValorAnteriorInt = AponusDBContext.StockMensurables
                .Where(x => x.IdComponente == Actualizacion.IdExistencia)
                .Select(x => x.CantidadRecibido)
                .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockMensurables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadRecibido, ValorAnteriorInt - Actualizacion.Valor));
                ValorAnteriorInt = null;
            }
        }

        internal void DescontarGranallado(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadGranallado)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadGranallado, ValorAnteriorInt - Actualizacion.Valor));
                ValorAnteriorInt = null;

            }

        }
        internal void DescontarPintura(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;
            ValorAnteriorDec = null;

            //Pesables
            ValorAnteriorDec = AponusDBContext.StockPesables
              .Where(x => x.IdComponente == Actualizacion.IdExistencia)
              .Select(x => x.CantidadPintura)
              .SingleOrDefault();

            if (ValorAnteriorDec != null)
            {
                AponusDBContext.StockPesables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadPintura, ValorAnteriorDec - Convert.ToDecimal(Actualizacion.Valor)));
                ValorAnteriorDec = null;
            }

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadPintura)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadPintura, ValorAnteriorInt - Actualizacion.Valor));
                ValorAnteriorInt = null;
            }

        }

        internal void DescontarProceso(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;
            ValorAnteriorDec = null;

            //Pesables
            ValorAnteriorDec = AponusDBContext.StockPesables
              .Where(x => x.IdComponente == Actualizacion.IdExistencia)
              .Select(x => x.CantidadProceso)
              .SingleOrDefault();

            if (ValorAnteriorDec != null)
            {
                AponusDBContext.StockPesables
                               .Where(x          => x.IdComponente == Actualizacion.IdExistencia)
                               .ExecuteUpdate(x  => x.SetProperty(x => x.CantidadProceso, ValorAnteriorDec - Convert.ToDecimal(Actualizacion.Valor)));
                ValorAnteriorDec                 = null;
            }

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadProceso)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso, ValorAnteriorInt - Actualizacion.Valor));
                ValorAnteriorInt = null;
            }

            //Mensurables
            ValorAnteriorInt = AponusDBContext.StockMensurables
                .Where(x => x.IdComponente == Actualizacion.IdExistencia)
                .Select(x => x.CantidadProceso)
                .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockMensurables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso, ValorAnteriorInt - Actualizacion.Valor));
                ValorAnteriorInt = null;
            }
        }

        internal void DescontarMoldeado(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;
            ValorAnteriorDec = null;

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadMoldeado)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadMoldeado, ValorAnteriorInt - Actualizacion.Valor));
                ValorAnteriorInt = null;
            }


        }


        //-----SET----------

        internal void SetRecibidos(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;
            ValorAnteriorDec = null;

            //Pesables
            ValorAnteriorDec = AponusDBContext.StockPesables
              .Where(x => x.IdComponente == Actualizacion.IdExistencia)
              .Select(x => x.CantidadRecibido)
              .SingleOrDefault();

            if (ValorAnteriorDec != null)
            {
                AponusDBContext.StockPesables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadRecibido, Convert.ToDecimal(Actualizacion.Valor)));
                ValorAnteriorDec = null;
            }

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadRecibido)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadRecibido, Actualizacion.Valor));
                ValorAnteriorInt = null;
            }

            //Mensurables
            ValorAnteriorInt = AponusDBContext.StockMensurables
                .Where(x => x.IdComponente == Actualizacion.IdExistencia)
                .Select(x => x.CantidadRecibido)
                .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockMensurables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadRecibido, Actualizacion.Valor));
                ValorAnteriorInt = null;
            }
        }

        internal void SetGranallado(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadGranallado)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadGranallado, Actualizacion.Valor));
                ValorAnteriorInt = null;

            }

        }
        internal void SetPintura(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;
            ValorAnteriorDec = null;

            //Pesables
            ValorAnteriorDec = AponusDBContext.StockPesables
              .Where(x => x.IdComponente == Actualizacion.IdExistencia)
              .Select(x => x.CantidadPintura)
              .SingleOrDefault();

            if (ValorAnteriorDec != null)
            {
                AponusDBContext.StockPesables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadPintura, Convert.ToDecimal(Actualizacion.Valor)));
                ValorAnteriorDec = null;
            }

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadPintura)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadPintura, Actualizacion.Valor));
                ValorAnteriorInt = null;
            }

        }

        internal void SetProceso(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;
            ValorAnteriorDec = null;

            //Pesables
            ValorAnteriorDec = AponusDBContext.StockPesables
              .Where(x => x.IdComponente == Actualizacion.IdExistencia)
              .Select(x => x.CantidadProceso)
              .SingleOrDefault();

            if (ValorAnteriorDec != null)
            {
                AponusDBContext.StockPesables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso, Convert.ToDecimal(Actualizacion.Valor)));
                ValorAnteriorDec = null;
            }

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadProceso)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso, Actualizacion.Valor));
                ValorAnteriorInt = null;
            }

            //Mensurables
            ValorAnteriorInt = AponusDBContext.StockMensurables
                .Where(x => x.IdComponente == Actualizacion.IdExistencia)
                .Select(x => x.CantidadProceso)
                .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockMensurables
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso, Actualizacion.Valor));
                ValorAnteriorInt = null;
            }
        }

        internal void SetMoldeado(ActualizacionStock Actualizacion)
        {
            ValorAnteriorInt = null;
            ValorAnteriorDec = null;

            //Cuantitativos
            ValorAnteriorInt = AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .Select(x => x.CantidadMoldeado)
               .SingleOrDefault();

            if (ValorAnteriorInt != null)
            {
                AponusDBContext.StockCuantitativos
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadMoldeado, Actualizacion.Valor));
                ValorAnteriorInt = null;
            }


        }

        internal void ObtenerComponentes (ActualizacionStock Actualizacion)
        {
            List<DTOComponentesProducto>? ListadoComponentes = new List<DTOComponentesProducto>();

            //ActualizarComponente Insumos Cuantitativos
            ListadoComponentes = null;
            ListadoComponentes = new List<DTOComponentesProducto>();

            ListadoComponentes = AponusDBContext.ComponentesCuantitativos
                       .Where(x => x.IdProducto == Actualizacion.IdExistencia)
                       .Select(x => new DTOComponentesProducto
                       {
                           IdComponente = x.IdComponente,
                           Cantidad = x.Cantidad * Actualizacion.Valor
                       })
                       .ToList();

            foreach (DTOComponentesProducto Componentes in ListadoComponentes)
            {

                AponusDBContext.StockCuantitativos
                    .Where(x => x.IdComponente == Componentes.IdComponente)
                    .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso,
                    AponusDBContext.StockCuantitativos
                    .Where(x => x.IdComponente == Componentes.IdComponente)
                    .Select(x => x.CantidadProceso).SingleOrDefault() - Componentes.Cantidad));
            }
            if (Actualizacion.IdBulon == null)
            {

                //Actualiazr Insumos Pesables
                ListadoComponentes = null;
                ListadoComponentes = new List<DTOComponentesProducto>();

                ListadoComponentes = AponusDBContext.ComponentesPesables
                            .Where(x => x.IdProducto == Actualizacion.IdExistencia)
                            .Select(x => new DTOComponentesProducto
                            {
                                IdComponente = x.IdComponente,
                                Peso = x.Peso * Actualizacion.Valor
                            })
                            .ToList();

                foreach (DTOComponentesProducto Componentes in ListadoComponentes)
                {

                    AponusDBContext.StockPesables
                        .Where(x => x.IdComponente == Componentes.IdComponente)
                        .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso,
                        AponusDBContext.StockPesables
                        .Where(x => x.IdComponente == Componentes.IdComponente)
                        .Select(x => x.CantidadProceso).SingleOrDefault() - Componentes.Peso));
                }

            }
            //ActualizarComponente Insumos Mensurables
            ListadoComponentes = null;
            ListadoComponentes = new List<DTOComponentesProducto>();

            if (Actualizacion.IdJuntaPerfil != null)
            {
                ListadoComponentes = AponusDBContext.ComponentesMensurables
                       .Where(x => x.IdProducto == Actualizacion.IdExistencia && x.IdComponente == Actualizacion.IdJuntaPerfil)
                       .Select(x => new DTOComponentesProducto
                       {
                           IdComponente = x.IdComponente,
                           Largo = x.Largo * Actualizacion.Valor
                       })
                       .ToList();

                foreach (DTOComponentesProducto Componentes in ListadoComponentes)
                {

                    AponusDBContext.StockMensurables
                        .Where(x => x.IdComponente == Componentes.IdComponente)
                        .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso,
                        AponusDBContext.StockMensurables
                        .Where(x => x.IdComponente == Componentes.IdComponente)
                        .Select(x => x.CantidadProceso).SingleOrDefault() - Componentes.Largo));
                }
            }

            else if (Actualizacion.IdBulon != null) //Completar peso del bulon especificado
            {
                //Actualiazr Insumos Pesables
                ListadoComponentes = null;
                ListadoComponentes = new List<DTOComponentesProducto>();

                ListadoComponentes = AponusDBContext.ComponentesPesables
                            .Where(x => x.IdProducto == Actualizacion.IdExistencia && x.IdComponente.Contains("BUL")==false)
                            .Select(x => new DTOComponentesProducto
                            {
                                IdComponente = x.IdComponente,
                                Peso = x.Peso * Actualizacion.Valor
                            })
                            .ToList();


                foreach (DTOComponentesProducto Componentes in ListadoComponentes)
                {

                    AponusDBContext.StockPesables
                        .Where(x => x.IdComponente == Componentes.IdComponente)
                        .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso,
                        AponusDBContext.StockPesables
                        .Where(x => x.IdComponente == Componentes.IdComponente)
                        .Select(x => x.CantidadProceso).SingleOrDefault() - Componentes.Peso));
                }

            }    

        }

        internal bool AgregarProducto(ActualizacionStock Actualizacion)
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

        internal bool RestarProducto(ActualizacionStock Actualizacion, AponusContext? AponusDBContext = null)
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

        internal async Task<List<Data_Transfer_objects.Insumos>> ListarBulones()
        {
            List<Data_Transfer_objects.Insumos> Bulones= new List<Data_Transfer_objects.Insumos>();
            Bulones = await AponusDBContext.PesablesDetalles
                .Where(x=>x.IdComponente.Contains("BUL")==true)
                .Select(x=>new Data_Transfer_objects.Insumos
                {
                    IdInsumo = x.IdComponente,
                    Nombre = x.Altura.ToString(),
                }).ToListAsync();

            return Bulones;
        }

        internal async Task<List<Data_Transfer_objects.Insumos>> ListarPerfilesJuntas()
        {
            List<Data_Transfer_objects.Insumos> PerfilesJuntas = new List<Data_Transfer_objects.Insumos>();
            PerfilesJuntas = await AponusDBContext.MensurablesDetalles
                .Where(x => x.IdComponente.Contains("JUN") == true)
                .Select(x => new Data_Transfer_objects.Insumos
                {
                    IdInsumo = x.IdComponente,
                    Nombre = x.Perfil.ToString(),
                }).ToListAsync();

            return PerfilesJuntas;
        }



        internal  IActionResult Listar(int? IdDescripcion=null)
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
                                new DTOComponenteFormateado
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

        internal string? CrearDirectorioMovimientos(string Proveedor)
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

        internal List<ArchivosMovimientosStock> CopiarArchivosMovimientos(List<IFormFile> Archivos, string Directorio)
        {
            List<ArchivosMovimientosStock> MovimientosStockArchivosList = new List<ArchivosMovimientosStock>();
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
