using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Mapping;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Aponus_Web_API.Business
{
    public class BS_Stocks
    {
        internal  async Task<List<TipoInsumos>>Listar()
        {
            return   await new ObtenerStocks().Listar();
        }

        internal async Task<List<TipoInsumos>> Listar(int? idDescripcion, int? dn)
        {
            return await new ObtenerStocks().Listar(idDescripcion,dn);
        }

        internal async Task<List<TipoInsumos>> Listar(int? idDescripcion)
        {
            return await new ObtenerStocks().Listar(idDescripcion);
        }

        internal async Task<JsonResult> ListarDiametros(int? idDescripcion)
        {
            return await new ObtenerStocks().ListarDiametros(idDescripcion);
        }

        internal async Task<List<TipoInsumos>> ListarTipoInsumos()
        {
            return await new ObtenerStocks().ListarTipoInsumos();
        }

        internal IActionResult ActualizarStock(ActualizacionStock Actualizacion)
        {
            try
            {
                switch (Actualizacion.IdTipoExistencia)
                {
                    case 0:
                        switch (Actualizacion.Operador)
                        {
                            case "+":
                                new ModificacionesStocks().ActualizarInsumo_Aumentar(Actualizacion);
                                return new JsonResult(new StatusCodeResult(200));                                
                            case "-":
                                new ModificacionesStocks().ActualizarInsumo_Descontar(Actualizacion);
                                return new JsonResult(new StatusCodeResult(200));
                            case "=":
                                new ModificacionesStocks().ActualizarInsumo_NuevoValor(Actualizacion);
                                return new JsonResult(new StatusCodeResult(200));
                           
                        }
                        break;

                    case 1:

                        switch (Actualizacion.Operador)
                        {
                            case "+":
                                new ModificacionesStocks().ActualizarProducto_Agregar(Actualizacion);
                                return new JsonResult(new StatusCodeResult(200));
                            case "-":
                                new ModificacionesStocks().ActualizarProducto_Descontar(Actualizacion);
                                return new JsonResult(new StatusCodeResult(200));
                            case "=":
                                new ModificacionesStocks().ActualizarProducto_NuevoValor(Actualizacion);
                                return new JsonResult(new StatusCodeResult(200));                           
                        }
                        break;

                    
                }
                return new JsonResult(new StatusCodeResult(200));

            }
            catch (Exception)
            {

                return new JsonResult(new StatusCodeResult(400));


            }
        }

        internal void ObtenerCampos(int tipo, string id)
        {
            switch (tipo)
            {
                case 0:
                    //new OperacionesStocks().ObtenerCamposInsumo(id);
                    break;
                default:
                    break;
            }
        }

        internal void ActualizarProducto(ActualizacionStock actualizacion)
        {
            throw new NotImplementedException();
        }
    }
}
