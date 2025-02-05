using Aponus_Web_API.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class DashBoardController : Controller
    {

        private readonly BS_Dashboard BsDashboard;

        public DashBoardController(BS_Dashboard _bsDashboard)
        {
            BsDashboard = _bsDashboard;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> ObtenerDatosTablero()
        {
            return await BsDashboard.ProcesarDatosTablero();
        }
    }
}
