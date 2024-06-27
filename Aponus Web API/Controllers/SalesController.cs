using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Services.Ventas;
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
            return null;

        }


        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Guardar (DTOVentas Venta)
        {
            if(Venta.SaldoTotal.Equals(0))
                return new ContentResult()
                {
                    Content="El valor de la venta no puede ser 0.00",
                    ContentType="Application/Json",
                    StatusCode = 400
                };
            else
            {
                
                return await BS_Ventas.Guardar(Venta);
            }


        }




    }
}
