using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Aponus_Web_API.Support.Ventas;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]

    public class SalesController : Controller
    {
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List(FiltrosVentas? Filtros)
        {
            return await BS_Ventas.Filtrar(Filtros);

        }

        [HttpGet]
        [Route("Quotation")]
        public async Task<IActionResult> GenerarCuotas(ParametrosCalcularCuotas Parametros)
        {
            try
            {


                ICollection<DTOCuotasVentas> ListadoCuotas = await BS_Ventas.CalcularCuotas(Parametros);

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
        [Route("States/New")]
        public async Task<IActionResult> GuardarEstadoVenta(DTOEstadosVentas Estados)
        {
            return await BS_Ventas.Estados.ValidarDatos(Estados);
        }

        //

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Guardar (DTOVentas Venta)
        {
             // If Venta.Cuotas es nulo errror 

            if(Venta.Monto.Equals(0))
                return new ContentResult()
                {
                    Content="El valor de la venta no puede ser 0.00",
                    ContentType="Application/Json",
                    StatusCode = 400
                };
            else
            {
                
                return await BS_Ventas.ProcesarDatosVenta(Venta);
            }


        }

        //Agregar Estados Ventas
        //Agregar TIPO y  CATEGORIA de ENTIDADES , en 'Entidades'



    }
}
