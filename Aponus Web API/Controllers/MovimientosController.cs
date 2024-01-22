using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class MovimientosController : Controller
    {

        [HttpGet]
        [Route("List")]

        ////NewStockUpdate en STockControllers = NuevoMovimiento, Actualizacion

        public IActionResult Listar(FiltrosMovimientos? Filtros)
        {
            return new BS_Movimientos().Listar(Filtros);
        }
    }
}
