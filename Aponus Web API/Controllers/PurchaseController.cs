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
        public async Task<IActionResult> NuevaCompra(DTOCompras Compras)
        {
            return await BsCompras.ProcesarDatosCompra(Compras);
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> Listar(UTL_FiltrosComprasVentas? Filtros)
        {
            return await BsCompras.Listar(Filtros);
        }

        [HttpPost]
        [Route("Billings/New")]

        public async Task<IActionResult> RegistrarPago(DTOPagosCompras Pago)
        {
            return await BsCompras.RegistrarPago(Pago);
        }

        //Modiicar Stock cunado se elimina o modifica una compra

    }
}
