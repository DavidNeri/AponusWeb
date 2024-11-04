using Aponus_Web_API.Utilidades.Servicios_BIN;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class BINServicesController : Controller
    {
        [HttpGet]
        [Route("GetCardInfo/{BIN}")]
        public async Task<IActionResult> ObtenerInformacionTarjeta(string BIN)
        {
            if (BIN.Length < 6)
            {
                return new JsonResult("Faltan Datos");
            }
            else
            {
                return await new UTL_IdentificacionesBancarias().ObtenerDatosTarjeta(BIN);
            }

        }
    }
}
