using Aponus_Web_API.Data_Transfer_Objects;
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
