using Microsoft.AspNetCore.Mvc;
using Aponus_Web_API.Business;
using Aponus_Web_API.Mapping;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class StocksController : Controller
    {
        [HttpGet]
        [Route("List/All")]

        public  async Task<List<TipoInsumos>> Listar() 
        {
            return  await   new BS_Stocks().Listar();

        }
    }
}
