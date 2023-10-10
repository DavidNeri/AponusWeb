using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class ComponentsController : Controller
    {
        [HttpGet]
        [Route("FetchUnities")]

        public async Task<IActionResult> ObtenerAlmacenamiento()
        {
            try
            {
                return await new BS_Components().ObtenerTipoAlmacenamiento();
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
        }

        [HttpGet]
        [Route("GetProperties")]

        public  IActionResult ObtenerPropsComponentes()
        {
            try
            {
                return  new BS_Components().ObtenerPropsComponentes();
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
        }

        [HttpPost]
        [Route("SaveComponent")]

        public IActionResult ObtenerPropsComponentes(DTOComponente componente)
        {
            try
            {
                return new BS_Components().GuardarComponente(componente);
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
        }

        [HttpGet]
        [Route("List/{IdDescripcion?}")]

        public IActionResult ListarComponentes(int? IdDescripcion)
        {
            try
            {
                return new BS_Components().ListarComponentes(IdDescripcion);
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
        }
    }
}
