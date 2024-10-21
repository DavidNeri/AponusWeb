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
        private readonly BS_Ventas BsVentas;
        public SalesController(BS_Ventas bsVentas)
        {
            BsVentas = bsVentas;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List(FiltrosVentas? Filtros)
        {
            return BsVentas.Filtrar(Filtros);

        }

        [HttpGet]
        [Route("Quotation")]
        public IActionResult GenerarCuotas(ParametrosCalcularCuotas Parametros)
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
        public async Task<IActionResult> Guardar (DTOVentas Venta)
        {
             // If Venta.Cuotas es nulo errror 

            if(Venta.Total.Equals(0))
                return new ContentResult()
                {
                    Content="El valor de la venta no puede ser 0.00",
                    ContentType="Application/Json",
                    StatusCode = 400
                };
            else
            {
                try
                {
                    return await BsVentas.ProcesarDatosVenta(Venta);
                }
                catch (Exception ex )
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException?.Message ?? ex.Message,
                        ContentType="applcation/json",
                        StatusCode=400
                    };
                }  
                
            }


        }




    }
}
