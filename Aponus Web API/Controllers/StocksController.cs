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

        public async Task<List<TipoInsumos>> Listar()
        {
            return await new BS_Stocks().Listar();

        }

        [HttpGet]
        [Route("List/Types")]

        public async Task<List<TipoInsumos>> ListarTipoInsumos() 
        {
            return await new BS_Stocks().ListarTipoInsumos();
        }

        [HttpGet]
        [Route("List/{idDescription}/{dn}")]

        public async Task<List<TipoInsumos>> Listar(int? idDescription, int? Dn)
        {
            return await new BS_Stocks().Listar (idDescription, Dn);

        }

        [HttpGet]
        [Route("List/{idDescription}")]

        public async Task<List<TipoInsumos>> Listar(int? idDescription)
        {
            return await new BS_Stocks().Listar(idDescription);

        }

        [HttpGet]
        [Route("List/Diameters/{idDescription}/")]

        public async Task<JsonResult> ListarDiametros(int? idDescription)
        {
            return await new BS_Stocks().ListarDiametros(idDescription);

        }
    }
}
