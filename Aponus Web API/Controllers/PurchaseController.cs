using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class PurchaseController : Controller
    {

        [HttpGet]
        [Route("New")]
        public async Task<IActionResult> NuevaCompra(DTOCompras Compras)
        {
            return null;
        }


    }
}
