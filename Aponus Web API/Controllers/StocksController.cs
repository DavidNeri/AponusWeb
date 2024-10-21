using Microsoft.AspNetCore.Mvc;
using Aponus_Web_API.Negocio;
using Aponus_Web_API.Data_Transfer_objects;
using System.IO;
using System.Drawing.Drawing2D;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Microsoft.Build.Framework;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class StocksController : Controller
    {
        private readonly BS_Stocks BsStocks;
        public StocksController(BS_Stocks bsStocks)
        {
            BsStocks = bsStocks;
        }

        [HttpGet]
        [Route("Supplies/List/{idDescription?}")]
        public IActionResult NewListar(int? idDescription)
        {
            return  BsStocks.ObtenerDatosInsumos(idDescription);
        } 

        [HttpGet]
        [Route("Products/List/{TypeId}/{IdDescription}")]
        public JsonResult ListProducts(string TypeId, int IdDescription)
        {
            try
            {
                return BsStocks.ListarProductos(TypeId, IdDescription);
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
            return await BsStocks.OperacionesStockInsumos().Actualizar(StockInsumo);
        }

        [HttpPost]
        [Route("Products/Update")]
        public async Task<IActionResult> Actualizar(DTOStockProductos StockProducto)
        {
            return await BsStocks.OperacionesStockProductos().Actualizar(StockProducto);
        }

        [HttpPost]
        [Route("Products/Increment")]
        public async Task<IActionResult> Incrementar(DTOProducto Producto)
        {
            return await BsStocks.OperacionesStockProductos().Incrementar(Producto);
            
        }

    }
}
