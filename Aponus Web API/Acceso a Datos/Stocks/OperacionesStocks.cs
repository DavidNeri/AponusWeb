using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using NtpClient;
using System.Net.NetworkInformation;
using System.ComponentModel.DataAnnotations;

namespace Aponus_Web_API.Acceso_a_Datos.Stocks
{
    public class OperacionesStocks
    {
        private readonly AponusContext AponusDBContext;
        public OperacionesStocks() { AponusDBContext = new AponusContext(); }
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
               .Where(x => x.IdComponente == Actualizacion.IdExistencia)
               .ExecuteUpdate(x => x.SetProperty(x => x.CantidadProceso, ValorAnteriorDec - Convert.ToDecimal(Actualizacion.Valor)));
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

        internal bool RestarProducto(ActualizacionStock Actualizacion)
        {
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

                resultado=false;
            }

            return resultado;
           
        }

        internal bool SetCantidadProducto(ActualizacionStock Actualizacion)
        {
            bool resultado = true;
            try
            {
                AponusDBContext.Productos
               .Where(x => x.IdProducto == Actualizacion.IdExistencia)
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

        internal async Task<List<TipoInsumos>> Listar()
        {

            List<TipoInsumos> tipoInsumosList =  await AponusDBContext.ComponentesDetalles
                 .Join(AponusDBContext.ComponentesDescripcions,
                 Detalles => Detalles.IdDescripcion,
                 Descripciones => Descripciones.IdDescripcion,
                 (Detalles, Descripciones) => new { Detalles,Descripciones}
                 )
                 .Join(AponusDBContext.stockInsumos,
                        JoinResult=>JoinResult.Detalles.IdInsumo,
                        Stock=>Stock.IdInsumo,
                        (JoinResult,Stock)=>new TipoInsumos
                        {
                            IdDescripcion = JoinResult.Descripciones.IdDescripcion,
                            Descripcion = JoinResult.Descripciones.Descripcion,
                            Especificaciones = new List<DTOComponente>
                            {
                                new DTOComponente
                                {
                                    // IdDescripcion = JoinResult.Detalles.IdDescripcion,
                                    idComponente = JoinResult.Detalles.IdInsumo,
                                    Largo = JoinResult.Detalles.Longitud,
                                    Espesor = JoinResult.Detalles.Espesor,
                                    Perfil = JoinResult.Detalles.Perfil,
                                    Diametro = JoinResult.Detalles.Diametro,
                                    Altura = JoinResult.Detalles.Altura,
                                    Tolerancia = JoinResult.Detalles.Tolerancia,
                                    Recibido = Stock.CantidadRecibido.ToString(),
                                    Granallado = Stock.CantidadGranallado.ToString(),
                                    Pintura = Stock.CantidadPintura.ToString(),
                                    Proceso = Stock.CantidadProceso.ToString(),
                                    Moldeado = Stock.CantidadMoldeado.ToString(),
                                    DiametroNominal= JoinResult.Detalles.DiametroNominal

                                }
                            }
                        })

                 .GroupBy(Result => new
                 {
                     Result.IdDescripcion,
                     Result.Descripcion
                 })
                 .Select(group => new TipoInsumos
                 {  
                     IdDescripcion = group.Key.IdDescripcion,
                     Descripcion = group.Key.Descripcion,
                     Especificaciones = group.Select(result => result.Especificaciones.Single()).ToList()                    
                 }).ToListAsync();


            foreach (TipoInsumos ListaInsumos in tipoInsumosList)
            {
                ListaInsumos.Columnas = new ColumnasJson().NewSetColumnas(ListaInsumos.Especificaciones);
            }
                    


            return tipoInsumosList;


        }

        internal async Task<List<TipoInsumos>> Listar(int? idDescripcion)
        {
            List<TipoInsumos> tipoInsumosList = await AponusDBContext.ComponentesDetalles
                             .Join(AponusDBContext.ComponentesDescripcions,
                             Detalles => Detalles.IdDescripcion,
                             Descripciones => Descripciones.IdDescripcion,
                             (Detalles, Descripciones) => new { Detalles, Descripciones }
                             )
                             .Where(JoinResult=>JoinResult.Descripciones.IdDescripcion==idDescripcion)
                             .Join(AponusDBContext.stockInsumos,
                                    JoinResult => JoinResult.Detalles.IdInsumo,
                                    Stock => Stock.IdInsumo,
                                    (JoinResult, Stock) => new TipoInsumos
                                    {
                                        IdDescripcion = JoinResult.Descripciones.IdDescripcion,
                                        Descripcion = JoinResult.Descripciones.Descripcion,
                                        Especificaciones = new List<DTOComponente>
                                        {
                                new DTOComponente
                                {
                                    // IdDescripcion = JoinResult.Detalles.IdDescripcion,
                                    idComponente = JoinResult.Detalles.IdInsumo,
                                    Largo = JoinResult.Detalles.Longitud,
                                    Espesor = JoinResult.Detalles.Espesor,
                                    Perfil = JoinResult.Detalles.Perfil,
                                    Diametro = JoinResult.Detalles.Diametro,
                                    Altura = JoinResult.Detalles.Altura,
                                    Tolerancia = JoinResult.Detalles.Tolerancia,
                                    Recibido = Stock.CantidadRecibido.ToString(),
                                    Granallado = Stock.CantidadGranallado.ToString(),
                                    Pintura = Stock.CantidadPintura.ToString(),
                                    Proceso = Stock.CantidadProceso.ToString(),
                                    Moldeado = Stock.CantidadMoldeado.ToString(),
                                    DiametroNominal= JoinResult.Detalles.DiametroNominal

                                }
                                        }
                                    })

                             .GroupBy(Result => new
                             {
                                 Result.IdDescripcion,
                                 Result.Descripcion
                             })
                             .Select(group => new TipoInsumos
                             {
                                 IdDescripcion = group.Key.IdDescripcion,
                                 Descripcion = group.Key.Descripcion,
                                 Especificaciones = group.Select(result => result.Especificaciones.Single()).ToList()
                             }).ToListAsync();

            return tipoInsumosList;
        }

        internal async Task<List<TipoInsumos>> Listar(int? idDescripcion, int? dN)
        {
            
            List<TipoInsumos> tipoInsumosList = await AponusDBContext.ComponentesDetalles
                            .Join(AponusDBContext.ComponentesDescripcions,
                            Detalles => Detalles.IdDescripcion,
                            Descripciones => Descripciones.IdDescripcion,
                            (Detalles, Descripciones) => new { Detalles, Descripciones }
                            )
                            .Where(JoinResult => JoinResult.Descripciones.IdDescripcion == idDescripcion && JoinResult.Detalles.DiametroNominal==dN)
                            .Join(AponusDBContext.stockInsumos,
                                   JoinResult => JoinResult.Detalles.IdInsumo,
                                   Stock => Stock.IdInsumo,
                                   (JoinResult, Stock) => new TipoInsumos
                                   {
                                       IdDescripcion = JoinResult.Descripciones.IdDescripcion,
                                       Descripcion = JoinResult.Descripciones.Descripcion,
                                       Especificaciones = new List<DTOComponente>
                                       {
                                new DTOComponente
                                {
                                    // IdDescripcion = JoinResult.Detalles.IdDescripcion,
                                    idComponente = JoinResult.Detalles.IdInsumo,
                                    Largo = JoinResult.Detalles.Longitud,
                                    Espesor = JoinResult.Detalles.Espesor,
                                    Perfil = JoinResult.Detalles.Perfil,
                                    Diametro = JoinResult.Detalles.Diametro,
                                    Altura = JoinResult.Detalles.Altura,
                                    Tolerancia = JoinResult.Detalles.Tolerancia,
                                    Recibido = Stock.CantidadRecibido.ToString(),
                                    Granallado = Stock.CantidadGranallado.ToString(),
                                    Pintura = Stock.CantidadPintura.ToString(),
                                    Proceso = Stock.CantidadProceso.ToString(),
                                    Moldeado = Stock.CantidadMoldeado.ToString(),
                                    DiametroNominal= JoinResult.Detalles.DiametroNominal
                                }
                                       }
                                   })

                            .GroupBy(Result => new
                            {
                                Result.IdDescripcion,
                                Result.Descripcion
                            })
                            .Select(group => new TipoInsumos
                            {
                                IdDescripcion = group.Key.IdDescripcion,
                                Descripcion = group.Key.Descripcion,
                                Especificaciones = group.Select(result => result.Especificaciones.Single()).ToList()
                            }).ToListAsync();

            return tipoInsumosList;
        }

        internal bool IncrementarStockInsumo(ActualizacionStock Actualizacion, string? Prop)
        {
            bool result = false;
            PropertyInfo? Propiedad = typeof(StockInsumos).GetProperties().FirstOrDefault(p => p.Name.Contains(Prop));

            try
            {
                var elementos = AponusDBContext.stockInsumos
                        .Where(x => x.IdInsumo == Actualizacion.Id)
                        .ToList();

                foreach (var elemento in elementos)
                {
                    decimal? valorSumar = Actualizacion.Valor ?? 0;

                    var valorActual = (decimal?)Propiedad?.GetValue(elemento);
                    if (valorActual == null) valorActual = 0;

                    decimal? nuevoValor = (valorActual ?? 0) + valorSumar;

                    if (Propiedad != null)
                    {
                        Propiedad.SetValue(elemento, nuevoValor);
                    }
                }

                AponusDBContext.SaveChanges(); // Guardar los cambios en la base de datos

                result = true;
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DescontarStockInsumo(ActualizacionStock Actualizacion, string? Prop)
        {
            bool result = false;
            PropertyInfo? Propiedad = typeof(StockInsumos).GetProperties().FirstOrDefault(p => p.Name.Contains(Prop));

            try
            {
                var elementos = AponusDBContext.stockInsumos
                       .Where(x => x.IdInsumo == Actualizacion.Id)
                       .ToList();

                foreach (var elemento in elementos)
                {
                    decimal? valorSumar = Actualizacion.Valor ?? 0;

                    var valorActual = (decimal?)Propiedad?.GetValue(elemento);
                    if (valorActual == null) valorActual = 0;

                    decimal? nuevoValor = (valorActual ?? 0) - valorSumar;

                    if (Propiedad != null)
                    {
                        Propiedad.SetValue(elemento, nuevoValor);
                    }
                }

                AponusDBContext.SaveChanges(); // Guardar los cambios en la base de datos
                result = true;
                return result;
            }
            catch (Exception)
            {

                return false;
            }

           
        }

        public StockInsumos? BuscarInsumo(string Insumo)
        {
            return AponusDBContext.stockInsumos.Where(x => x.IdInsumo == Insumo).Select(x => new StockInsumos()
            {
                IdInsumo = x.IdInsumo,
                CantidadGranallado = x.CantidadGranallado,
                CantidadMoldeado = x.CantidadMoldeado,
                CantidadPintura = x.CantidadPintura,
                CantidadProceso = x.CantidadProceso,
                CantidadRecibido = x.CantidadRecibido

            }).SingleOrDefault();

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

        internal void GuardarMovimiento(ActualizacionStock actualizacion, decimal? valorOriginalOrigen, decimal? valorAntDestino)
        {
            //Obtner la letra de Directorio del Systema
            string DirectorioPadre = Path.Combine(Path.GetPathRoot(Environment.SystemDirectory),"Aponus");
            string DirectorioHijo= Path.Combine(DirectorioPadre, "Documentacion");
            string[] servidoresNTP = { "Time.Windows.com","pool.ntp.org", "south-america.pool.ntp.org", "Time.Windows.com" }; // Lista de servidores NTP
            bool ConexionExistosa = false;
            string [] NombresArchivos = new string[actualizacion.Archivos.Count];
            string Carpeta="";
            DateTime FechaHora = new DateTime();
            List<Stock_Movimientos> Movimientos = new List<Stock_Movimientos>();
            List<ArchivosMovimientosStock> MovimientosStockArchivosList = new List<ArchivosMovimientosStock>();

            //--Crear/Validar Directorio para la copia de Archivos           
            foreach (string Servidor in servidoresNTP)
            {
                try
                {
                    Ping ping = new Ping();
                    PingReply Respuesta = ping.Send(Servidor, 1000);

                    if (Respuesta!=null && Respuesta.Status== IPStatus.Success)
                    {
                        INtpConnection Conexion = new NtpConnection(Servidor);                        
                        Carpeta = Conexion.GetUtc().AddHours(-3).ToString("dd-MM-yyyy");
                        FechaHora = Conexion.GetUtc().AddHours(-3);
                        ConexionExistosa = true;
                        break;
                    }                   
                }
                catch (PingException){ }
            }

            if (ConexionExistosa == false)
            {
                Carpeta = DateTime.Now.ToString("dd-MM-yyyy");
                FechaHora = DateTime.Now;
            }

            for (int i = 0; i < NombresArchivos.Length; i++)
            {
                NombresArchivos[i] = Guid.NewGuid().ToString();//Conexion.GetUtc().AddHours(-3).ToString("yyyyMMddHHmmssffffff");
                MovimientosStockArchivosList.Add(new ArchivosMovimientosStock()
                {
                    HashArchivo = NombresArchivos[i].ToString(),
                });
            }

            _ =!Directory.Exists(DirectorioPadre)&&Carpeta!="" ? Directory.CreateDirectory(DirectorioPadre):null;
            _=!Directory.Exists(DirectorioHijo)? Directory.CreateDirectory(DirectorioHijo):null;
            _=!Directory.Exists(DirectorioHijo + @"\" + Carpeta) ? Directory.CreateDirectory(DirectorioHijo + @"\"+Carpeta):null;

            //Copiar Archivos
            int x = 0;

            foreach (IFormFile Archivo in actualizacion.Archivos)
            {
                var ExtensionArchivo = Path.GetExtension(Archivo.FileName);
                string NombreArchivo = NombresArchivos[x];
                ArchivosMovimientosStock UPDATEMovimientosStock_Archivos = MovimientosStockArchivosList.FirstOrDefault(x => x.HashArchivo.Equals(NombreArchivo));
                
                var RutaArchivo = Path.Combine(DirectorioPadre, DirectorioHijo, Carpeta, Path.GetFileNameWithoutExtension(NombresArchivos[x])+ExtensionArchivo);

                using (var FlujoArchivos = new FileStream(RutaArchivo, FileMode.Create))
                {
                    Archivo.CopyTo(FlujoArchivos);
                };
                UPDATEMovimientosStock_Archivos.PathArchivo = RutaArchivo.ToString();
                x++;

            }             
            //Guardar Movimiento en BD
            Stock_Movimientos Movimiento = new Stock_Movimientos()
            {
                
                IdUsuario = actualizacion.Usuario,
                FechaHora = FechaHora,
                
            };          

            AponusDBContext.Stock_Movimientos.Add(Movimiento);
            AponusDBContext.SaveChanges();

            int IdMovimiento = Movimiento.IdMovimiento;

            MovimientosStockArchivosList.ForEach(x => x.IdMovimiento = IdMovimiento);

            AponusDBContext.ArchivosStock.AddRange(MovimientosStockArchivosList);
            AponusDBContext.SaveChanges();

        }
    }
}
