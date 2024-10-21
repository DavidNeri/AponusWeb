using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class GeoNamesController : ControllerBase
    {
        [HttpGet]
        [Route("Countries")]
        public async Task<IActionResult> ListarPaises()
        {
            return await new NombresGeograficos().ListarPaises();
        }

        [HttpGet]
        [Route("Provinces_States/{geonameId}")]
        public async Task<IActionResult> ListarProvincias(int geonameId)
        {
            return await new NombresGeograficos().ListarProvincias(geonameId);
        }

        [HttpGet]
        [Route("Cities/{countryCode}/{adminCode1}")]
        public async Task<IActionResult> ListarProvincias(string countryCode, string adminCode1)
        {
            return await new NombresGeograficos().ListarCiudades(countryCode, adminCode1);
        }

    }
}
