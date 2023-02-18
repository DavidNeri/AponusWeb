using Aponus_Web_API.Mapping;
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
            List<ComponentesProducto>? ListadoComponentes = new List<ComponentesProducto>();

            //Actualizar Insumos Cuantitativos
            ListadoComponentes = null;
            ListadoComponentes = new List<ComponentesProducto>();

            ListadoComponentes = AponusDBContext.ComponentesCuantitativos
                       .Where(x => x.IdProducto == Actualizacion.IdExistencia)
                       .Select(x => new ComponentesProducto
                       {
                           IdComponente = x.IdComponente,
                           Cantidad = x.Cantidad * Actualizacion.Valor
                       })
                       .ToList();

            foreach (ComponentesProducto Componentes in ListadoComponentes)
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
                ListadoComponentes = new List<ComponentesProducto>();

                ListadoComponentes = AponusDBContext.ComponentesPesables
                            .Where(x => x.IdProducto == Actualizacion.IdExistencia)
                            .Select(x => new ComponentesProducto
                            {
                                IdComponente = x.IdComponente,
                                Peso = x.Peso * Actualizacion.Valor
                            })
                            .ToList();

                foreach (ComponentesProducto Componentes in ListadoComponentes)
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
            ListadoComponentes = new List<ComponentesProducto>();

            if (Actualizacion.IdJuntaPerfil != null)
            {
                ListadoComponentes = AponusDBContext.ComponentesMensurables
                       .Where(x => x.IdProducto == Actualizacion.IdExistencia && x.IdComponente == Actualizacion.IdJuntaPerfil)
                       .Select(x => new ComponentesProducto
                       {
                           IdComponente = x.IdComponente,
                           Largo = x.Largo * Actualizacion.Valor
                       })
                       .ToList();

                foreach (ComponentesProducto Componentes in ListadoComponentes)
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
                ListadoComponentes = new List<ComponentesProducto>();

                ListadoComponentes = AponusDBContext.ComponentesPesables
                            .Where(x => x.IdProducto == Actualizacion.IdExistencia && x.IdComponente.Contains("BUL")==false)
                            .Select(x => new ComponentesProducto
                            {
                                IdComponente = x.IdComponente,
                                Peso = x.Peso * Actualizacion.Valor
                            })
                            .ToList();


                foreach (ComponentesProducto Componentes in ListadoComponentes)
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
    }
}
