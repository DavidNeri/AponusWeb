using Microsoft.AspNetCore.Mvc;
using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_objects;
using System.IO;
using System.Drawing.Drawing2D;
using Aponus_Web_API.Data_Transfer_Objects;

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
            return  new BS_Stocks().ObtenerDatosInsumos(idDescription);
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

        [HttpPost]
        [Route("Supplies/Update")]
        public async Task<IActionResult> Actualizar(DTOStock StockInsumo)
        {
            return await BS_Stocks.Productos.Insumos.Actualizar(StockInsumo);
        }

        [HttpPost]
        [Route("Products/Update")]
        public async Task<IActionResult> Actualizar(DTOStockProductos StockProducto)
        {
            return await BS_Stocks.Productos.Actualizar(StockProducto);
        }

        [HttpPost]
        [Route("Products/Increment")]
        public async Task<IActionResult> Incrementar(DTOStockUpdate Producto)
        {
            return await BS_Stocks.Productos.Incrementar(Producto);
        
        }

    }
}
