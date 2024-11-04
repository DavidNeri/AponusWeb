using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]

    public class SalesController : Controller
    {
        private readonly BS_Ventas BsVentas;
        public SalesController(BS_Ventas bsVentas)
        {
            BsVentas = bsVentas;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List(UTL_FiltrosComprasVentas? Filtros)
        {
            return BsVentas.Filtrar(Filtros);

        }

        [HttpGet]
        [Route("Quotation")]
        public IActionResult GenerarCuotas(UTL_ParametrosCuotas Parametros)
        {
            try
            {
                ICollection<DTOCuotasVentas> ListadoCuotas = BS_Ventas.CalcularCuotas(Parametros);

                return new JsonResult(ListadoCuotas);

            }
            catch (Exception ex)
            {

                return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }

        }

        [HttpPost]
        [Route("States/Save")]
        public async Task<IActionResult> GuardarEstadoVenta(DTOEstadosVentas Estados)
        {
            return await BsVentas.EstadosVentas().ValidarDatos(Estados);
        }

        [HttpPost]
        [Route("States/{Id}/Delete")]
        public IActionResult EliminarEstadoVenta(int Id)
        {
            return BsVentas.EstadosVentas().Eliminar(Id);
        }

        //

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Guardar(DTOVentas Venta)
        {
            // If Venta.Cuotas es nulo errror 

            if (Venta.MontoTotal.Equals(0))
                return new ContentResult()
                {
                    Content = "El valor de la venta no puede ser 0.00",
                    ContentType = "Application/Json",
                    StatusCode = 400
                };
            else
            {
                try
                {
                    return await BsVentas.ProcesarDatosVenta(Venta);
                }
                catch (Exception ex)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        ContentType = "applcation/json",
                        StatusCode = 400
                    };
                }

            }


        }




    }
}
