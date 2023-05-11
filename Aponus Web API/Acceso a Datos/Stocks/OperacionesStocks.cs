using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Microsoft.EntityFrameworkCore;

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

            //Actualizar Insumos Cuantitativos
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
            //Actualizar Insumos Mensurables
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

        internal void AgregarProducto(ActualizacionStock Actualizacion)
        {
            AponusDBContext.Productos
                .Where(x => x.IdProducto == Actualizacion.IdExistencia)
                .ExecuteUpdate(x => x.SetProperty(x => x.Cantidad,
                AponusDBContext.Productos.
                Where(x => x.IdProducto == Actualizacion.IdExistencia).
                Select(x => x.Cantidad).SingleOrDefault() + Actualizacion.Valor));
        }

        internal void RestarProducto(ActualizacionStock Actualizacion)
        {
            AponusDBContext.Productos
                .Where(x => x.IdProducto == Actualizacion.IdExistencia)
                .ExecuteUpdate(x => x.SetProperty(x => x.Cantidad,
                AponusDBContext.Productos.
                Where(x => x.IdProducto == Actualizacion.IdExistencia).
                Select(x => x.Cantidad).SingleOrDefault() - Actualizacion.Valor));
        }

        internal void SetCantidadProducto(ActualizacionStock Actualizacion)
        {
            AponusDBContext.Productos
                .Where(x => x.IdProducto == Actualizacion.IdExistencia)
                .ExecuteUpdate(x => x.SetProperty(x => x.Cantidad,Actualizacion.Valor));
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
    }
}
