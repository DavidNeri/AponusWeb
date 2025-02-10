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
        [Route("PendingSales")]
        public async Task<IActionResult> ObtenerDatosVentasPendientesTablero()
        {
            return await BsDashboard.ProcesarVentasPendientesTablero();
        }


        [HttpGet]
        [Route("Supplies/{IdDescripcion}")]
        public async Task<IActionResult> ObtenerDatosInsumosTablero(int IdDescripcion)
        {
            return await BsDashboard.ProcesarInsumosFaltantesTablero(IdDescripcion);
        }

        [HttpGet]
        [Route("Products")]
        public IActionResult ObtenerDatosProductosTablero()
        {
            return  BsDashboard.ProcesarProductosFaltantesTablero();
        }

    }
}
