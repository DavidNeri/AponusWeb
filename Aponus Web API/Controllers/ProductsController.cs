using Aponus_Web_API.Business;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        [Route("ListProducts")]
        public async Task<JsonResult> ListProducts() {
            try
            {
                return new BS_Products().ProductsByProductName();
            }
            catch (Exception e )
            { 
                return Json(e);
            }
        }

        [HttpGet]
        [Route("ListProducts/{Type}")]
        public async Task<JsonResult> ListProducts(string? Type)
        {
            try
            {
                return new BS_Products().ProductsByType(Type);
            }
            catch (Exception e)
            {
                return Json(e); 
            }      


        }

        [HttpGet]
        [Route("ListParts/{ProductId}")]
        public async Task<JsonResult> ListParts(string? ProductId)
        {
            try
            {
                return new BS_Products().ListParts(ProductId);
            }
            catch (Exception e)
            {
                return Json(e);
            }


        }
    }
}
