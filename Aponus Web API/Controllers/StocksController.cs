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
        [Route("List/All")]

        public async Task<List<TipoInsumos>> Listar()
        {
            return await new BS_Stocks().Listar();

        }
      
        [HttpGet]
        [Route("List/{idDescription}")]

        public async Task<List<TipoInsumos>> Listar(int? idDescription)
        {
            return await new BS_Stocks().Listar(idDescription);

        }

        [HttpGet]
        [Route("List/{idDescription}/{dn}")]

        public async Task<List<TipoInsumos>> Listar(int? idDescription, int? Dn)
        {
            return await new BS_Stocks().Listar(idDescription, Dn);

        }       

        /// <summary>
        /// Reemplzo de List/All && List/{idDescription} && List/{idDescription}/{dn} Tablas Nuevas 
        /// Reemplaza 3 "/all - /iDDescripcion y  /iddescripcicion+DN
        /// </summary>
        /// <returns></returns>
        /// 
        /// 

        [HttpGet]
        [Route("NewList/{idDescription?}/{dn?}")]
        public async Task<List<TipoInsumos>> NewListar(int? idDescription, int? dn)
        {
            return await new BS_Stocks().NewListar(idDescription, dn);

        }

        ////
        ////
        ///

        [HttpGet]
        [Route("List/Types")]

        public async Task<List<TipoInsumos>> ListarTipoInsumos()
        {
            return await new BS_Stocks().ListarTipoInsumos();
        }

        
        [HttpGet]
        [Route("List/Diameters/{idDescription}/")]

        public async Task<JsonResult> ListarDiametros(int? idDescription)
        {
            return await new BS_Stocks().ListarDiametros(idDescription);

        }

        [HttpPost]
        [Route("StockUpdate")]
        public IActionResult ActualizarStock([FromForm] ActualizacionStock Actualizacion) {

            try
            {
                return new BS_Stocks().NewActualizarStock(Actualizacion);


                

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }        

        /// <summary>
        /// Reemplaza a StockUpdate
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("NewStockUpdate")] //-->Usar este
        public IActionResult NewActualizarStock(ActualizacionStock Actualizacion)
        {

            try
            {
                return new BS_Stocks().NewActualizarStock(Actualizacion);


            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }


        [HttpGet]
        [Route("List/Bolts")]
        public async Task<List<Insumos>> ListarBulones()
        {
            return await new BS_Stocks().ListarBulones();
        }

        [HttpGet]
        [Route("List/GasketsProfiles")]
        public async Task<List<Insumos>> ListarPerfilesJuntas()
        {
            return await new BS_Stocks().LIstarPerfilesJuntas();
        }





    }
}
