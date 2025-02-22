using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;

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
        //[RequiredPermission("COMPONENTES_DETALLE","SELECT")]
        //[RequiredPermission("COMPONENTES_DESCRIPCION", "SELECT")]
        //[RequiredPermission("STOCK_INSUMOS", "SELECT")]

        public IActionResult NewListar(int? idDescription)
        {
            return BsStocks.ObtenerDatosInsumos(idDescription);
        }

        [HttpGet]
        [Route("Products/List/{TypeId}/{IdDescription}")]
        [RequiredPermission("PRODUCTOS", "SELECT")]
        [RequiredPermission("PRODUCTOS_TIPO_DESCRIPCION", "SELECT")]
        [RequiredPermission("PRODUCTOS_TIPO", "SELECT")]
        [RequiredPermission("PRODUCTOS_DESCRIPCION", "SELECT")]
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
        [RequiredPermission("STOCK_INSUMOS", "INSERT")]
        [RequiredPermission("STOCK_INSUMOS", "UPDATE")]

        public async Task<IActionResult> Actualizar(DTOStock StockInsumo)
        {
            return await BsStocks.OperacionesStockInsumos().Actualizar(StockInsumo);
        }

        [HttpPost]
        [Route("Products/Update")]
        [RequiredPermission("PRODUCTOS", "INSERT")]
        [RequiredPermission("PRODUCTOS", "UPDATE")]

        public async Task<IActionResult> Actualizar(DTOStockProductos StockProducto)
        {
            return await BsStocks.OperacionesStockProductos().Actualizar(StockProducto);
        }

        [HttpPost]
        [Route("Products/Increment")]
        [RequiredPermission("PRODUCTOS", "INSERT")]
        [RequiredPermission("PRODUCTOS", "UPDATE")]
        [RequiredPermission("STOCK_INSUMOS", "UPDATE")]
        public async Task<IActionResult> Incrementar(DTOProducto Producto)
        {
            return await BsStocks.OperacionesStockProductos().Incrementar(Producto);
        }
    }
}
