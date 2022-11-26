using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly AponusContext AponusDBContext;

        public ProductsController(AponusContext aponusDBContext)
        {
            AponusDBContext = aponusDBContext;
        }
        [HttpGet]
       [Route("ListProducts")]
        public async Task<JsonResult> ListProducts()
        {
            List<Product> products = await AponusDBContext.Products.Include(x => x.Category).ToListAsync();
            products.OrderBy(x => x.ProductDescriptionName);
            return new JsonResult(products);

        }
        [HttpGet]
        [Route("ListProducts/{CategoryId}")]
        public async Task<JsonResult> ListProducts(string? CategoryId)
        {
            List<Product> products = await AponusDBContext.Products.Where(x => x.CategoryId.Equals(CategoryId)).ToListAsync();
            products.OrderBy(x => x.ProductDescriptionName);
            return new JsonResult(products);

        }
    }
}
