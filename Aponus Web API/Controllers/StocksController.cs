using Microsoft.AspNetCore.Mvc;
using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_objects;
using System.IO;
using System.Drawing.Drawing2D;

namespace Aponus_Web_API.Controllers
{
        [Route("Aponus/[Controller]")]
        [ApiController]
    public class StocksController : Controller
    {

        [HttpGet]
        [Route("Supplies/List/{idDescription?}")]
        public IActionResult NewListar(int? idDescription)
        {
            return  new BS_Stocks().NewListar(idDescription);
        } 

        [HttpGet]
        [Route("Products/List/{TypeId?}/{IdDescription?}")]
        public JsonResult ListProducts(string? TypeId, int? IdDescription)
        {
            try
            {
                return new BS_Stocks().ListarProductos(TypeId, IdDescription);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
