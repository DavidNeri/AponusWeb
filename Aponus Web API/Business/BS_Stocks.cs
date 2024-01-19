using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Aponus_Web_API.Acceso_a_Datos.Productos;

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
                                break;                                
                            case "-":
                                new ModificacionesStocks().ActualizarInsumo_Descontar(Actualizacion);
                                break;
                            case "=":
                                new ModificacionesStocks().ActualizarInsumo_NuevoValor(Actualizacion);
                                break;
                           
                        }
                        break;

                    case 1:

                        switch (Actualizacion.Operador)
                        {
                            case "+":
                                new ModificacionesStocks().ActualizarProducto_Agregar(Actualizacion);
                                break;
                            case "-":
                                new ModificacionesStocks().ActualizarProducto_Descontar(Actualizacion);
                                break;
                            case "=":
                                new ModificacionesStocks().ActualizarProducto_NuevoValor(Actualizacion);
                                break;
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

        internal IActionResult NewActualizarStock(ActualizacionStock Actualizacion)
        {
            try
            {

                if (new OperacionesStocks().BuscarInsumo(Actualizacion.Id)!=null)
                {

                     return new ModificacionesStocks().newActualizarStockInsumo(Actualizacion);
                 
                }
                else if (new OperacionesProductos().BuscarProducto(Actualizacion.Id)!=null)
                {

                    return new ModificacionesStocks().newActualizarStockProducto(Actualizacion);
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
            catch (Exception)
            {
                return new JsonResult(new StatusCodeResult(400));

            }
        }


        internal Task<List<Insumos>> ListarBulones()
        {
            return new OperacionesStocks().ListarBulones();
        }

        internal Task<List<Insumos>> LIstarPerfilesJuntas()
        {
            return new OperacionesStocks().ListarPerfilesJuntas();

        }

        internal Task<List<TipoInsumos>> NewListar(int? IdDescripcion, int? DN)
        {


            if (IdDescripcion == null && DN==null)
            {
                return new OperacionesStocks().Listar();

            }
            else if (IdDescripcion != null && DN == null)
            {
                return new OperacionesStocks().Listar(IdDescripcion);

            }
            else if (IdDescripcion != null && DN != null)
            {
                return new OperacionesStocks().Listar(IdDescripcion, DN);

            }
            else
            {
                return null;
            }


        }
    }
}
