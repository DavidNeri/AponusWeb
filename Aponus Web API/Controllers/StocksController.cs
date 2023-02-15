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
            return await new BS_Stocks().Listar(idDescription, Dn);

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

        [HttpPost]
        [Route("update")]
        public IActionResult Actualizar(ActualizarStock Actualizacion) {

            try
            {
                new BS_Stocks().Actualizar(Actualizacion);

                return StatusCode(200);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }


        }

        [HttpGet]
        [Route("qFields/{typeElement}/{id}")]

        public JsonResult Actualizar(int Tipo, string Id)
        {

            try
            {
                new BS_Stocks().ObtenerCampos(Tipo, Id);

                return new JsonResult(StatusCode(200));

            }
            catch (Exception)
            {

                return new JsonResult(StatusCode(500));
            }
        }
    }
}
