using Aponus_Web_API.Negocio;
using Aponus_Web_API.Utilidades;
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
        [Route("SalesAvg")]
        //[RequiredPermission("VENTAS", "SELECT")]
        //[RequiredPermission("VENTAS_DETALLES", "SELECT")]
        //[RequiredPermission("CUOTAS_VENTAS", "SELECT")]
        //[RequiredPermission("PAGOS_VENTAS", "SELECT")]
        //[RequiredPermission("ENTIDADES", "SELECT")]
        //[RequiredPermission("ARCHIVOS_VENTAS", "SELECT")]
        //[RequiredPermission("ESTADOS_VENTAS", "SELECT")]
        public IActionResult ObtenerVentasMensualesTablero()
        {
            return BsDashboard.ProcesarVentasMensuales();
        }



        [HttpGet]
        [Route("Supplies/{IdDescripcion}")]
        //[RequiredPermission("STOCK_INSUMOS", "SELECT")]
        //[RequiredPermission("COMPONENTES_DETALLE", "SELECT")]
        //[RequiredPermission("COMPONENTES_DESCRIPCION", "SELECT")]
        public async Task<IActionResult> ObtenerDatosInsumosTablero(int IdDescripcion)
        {
            return await BsDashboard.ProcesarInsumosFaltantesTablero(IdDescripcion);
        }

        [HttpGet]
        [Route("Products")]
        //[RequiredPermission("PRODUCTOS", "SELECT")]
        //[RequiredPermission("PRODUCTOS_DESCRIPCION", "SELECT")]
        //[RequiredPermission("PRODUCTOS_TIPOS", "SELECT")]

        public IActionResult ObtenerDatosProductosTablero()
        {
            return  BsDashboard.ProcesarProductosFaltantesTablero();
        }

    }
}
 