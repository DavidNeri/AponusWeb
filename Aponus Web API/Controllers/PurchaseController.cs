using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class PurchaseController : Controller
    {
        private readonly BS_Compras BsCompras;

        public PurchaseController(BS_Compras bsCompras)
        {
            BsCompras = bsCompras;
        }

        [HttpPost]
        [Route("Save")]
        [RequiredPermission("COMPRAS", "INSERT")]
        [RequiredPermission("COMPRAS", "UPDATE")]
        [RequiredPermission("COMPRAS_DETALLE", "INSERT")]
        [RequiredPermission("CUOTAS_COMPRAS", "INSERT")]
        [RequiredPermission("PAGOS_COMPRAS", "INSERT")]
        public async Task<IActionResult> NuevaCompra(DTOCompras Compras)
        {
            return await BsCompras.ProcesarDatosCompra(Compras);
        }

        [HttpGet]
        [Route("List")]
        [RequiredPermission("COMPRAS", "SELECT")]
        [RequiredPermission("COMPRAS_DETALLE", "SELECT")]
        [RequiredPermission("PAGOS_COMPRAS", "SELECT")]
        [RequiredPermission("MEDIOS_PAGO", "SELECT")]
        [RequiredPermission("CUOTAS_COMPRAS", "SELECT")]
        [RequiredPermission("ENTIDADES", "SELECT")]
        public async Task<IActionResult> Listar(UTL_FiltrosComprasVentas? Filtros)
        {
            return await BsCompras.Listar(Filtros);
        }

        [HttpPost]
        [Route("Bills/New")]
        [RequiredPermission("PAGOS_COMPRAS", "INSERT")]
        [RequiredPermission("PAGOS_VENTAS", "UPDATE")]

        public async Task<IActionResult> RegistrarPago(DTOPagosCompras Pago)
        {
            return await BsCompras.MapeoDTOPagosCompra(Pago);
        }

    }
}
