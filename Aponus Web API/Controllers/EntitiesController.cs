using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_Objects;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class EntitiesController : ControllerBase
    {
        private readonly BS_Entidades BSEntidades;
        public EntitiesController(BS_Entidades bSEntidades)
        {
            BSEntidades = bSEntidades;
        }

        [HttpGet]
        [Route("Types/List")]
        public async Task<IActionResult> ListarTiposEntidades()
        {
            return await BSEntidades.TiposEntidades().Listar();
        }

        [HttpPost]
        [Route("Types/Save")]

        public async Task<IActionResult> GuardarTipoEntidad(DTOEntidadesTipos TipoEntidad)
        {
            if (string.IsNullOrEmpty(TipoEntidad.Nombre))
            {
                return new ContentResult()
                {
                    Content = "El nombre no puede ser nulo",
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }
            else
            {
                return await BSEntidades.TiposEntidades().Guardar(TipoEntidad);
            }
        }


        [HttpGet]
        [Route("Categories/List/{IdTipo?}")]

        public async Task<IActionResult> ListarCategoriasEntidades(int? IdTipo)
        {
            return await BSEntidades.CategoriasEntidades().Listar(IdTipo);
        }
       

        [HttpPost]
        [Route("Categories/Save")]
        public async Task<IActionResult> GuardarCategoria(DTOEntidadesCategorias NuevaCategoria)
        {
            if (string.IsNullOrEmpty(NuevaCategoria.NombreCategoria))
            {
                return new ContentResult()
                {
                    Content = "El nombre no puede ser nulo",
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }
            else if (NuevaCategoria.IdTipo == null)
            {
                return new ContentResult()
                {
                    Content = "Se debe especificar el Tipo",
                    ContentType = "application/json",
                    StatusCode = 400
                };


            }
            else
            {
                return await BSEntidades.CategoriasEntidades().ValidarDatosCategoria(NuevaCategoria);
            }
        }
        [HttpPost]
        [Route("Categories/Delete/{Id}")]
        public IActionResult EliminarCategoria(int Id)
        {
            return BSEntidades.CategoriasEntidades().Eliminar(Id);
        }

        [HttpPost]
        [Route("Types/Delete/{Id}")]
        public IActionResult EliminarTipo(int Id)
        {
            return BSEntidades.TiposEntidades().Eliminar(Id);
        }
        

        [HttpPost]
        [Route("Save")]
        public IActionResult Nuevo(DTOEntidades Entidad)
        {
            return BSEntidades.Guardar(Entidad);
        }


        [HttpGet]
        [Route("List/{typeId=0}/{CategoryId=0}/{EntityId=0}")]
        public IActionResult Listar(int TypeId, int CategoryId, int EntityId)
        {            
            return BSEntidades.Listar(TypeId, CategoryId, EntityId);
        }       

        [HttpPost]
        [Route("Delete/{Id}")]
        public IActionResult Eliminar(int Id)
        {
            return BSEntidades.Eliminar(Id);
        }
    }
}
