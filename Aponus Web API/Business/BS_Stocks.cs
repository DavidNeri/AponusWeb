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

        internal IActionResult Actualizar(ActualizarStock Actualizacion)
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
                                break;
                            case "-":
                                new ModificacionesStocks().ActualizarInsumo_Descontar(Actualizacion);
                                break;
                            case "=":
                                new ModificacionesStocks().ActualizarInsumo_NuevoValor(Actualizacion);
                                break;
                            default:
                                break;
                        }
                        break;

                    case 1:
                        new ModificacionesStocks().ActualizarProducto(Actualizacion);
                        break;

                    default:
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
                    new OperacionesStocks().ObtenerCamposInsumo(id);
                    break;
                default:
                    break;
            }
        }
    }
}
