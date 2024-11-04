using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
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
            return await BSEntidades.TiposEntidades().MapeoTiposEntidadesDTO();
        }

        [HttpPost]
        [Route("Types/Save")]

        public async Task<IActionResult> Guardar(DTOEntidadesTipos TipoEntidad)
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
                return await BSEntidades.TiposEntidades().MapeoDTOTipoEntidadDB(TipoEntidad);
            }
        }


        [HttpGet]
        [Route("Categories/List/{IdTipo?}")]

        public async Task<IActionResult> ListarCategoriasEntidades(int? IdTipo)
        {
            return await BSEntidades.CategoriasEntidades().MapeoEntidadesCategoriasDTO(IdTipo);
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
                return await BSEntidades.CategoriasEntidades().MapeoNuevaCategoriaDB(NuevaCategoria);
            }
        }

        [HttpPost]
        [Route("Categories/Delete/{Id}")]
        public async Task<IActionResult> EliminarCategoria(int Id)
        {
            return await BSEntidades.CategoriasEntidades().ValidarCategoria(Id);
        }

        [HttpPost]
        [Route("Types/Delete/{Id}")]
        public async Task<IActionResult> EliminarTipo(int Id)
        {
            return await BSEntidades.TiposEntidades().ValidarTipoEntidad(Id);
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Nuevo(DTOEntidades Entidad)
        {
            return BSEntidades.ValidaryNormalizarDatos(Entidad);
        }

        [HttpGet]
        [Route("List/{typeId=0}/{CategoryId=0}/{EntityId=0}")]
        public IActionResult Listar(int TypeId, int CategoryId, int EntityId)
        {
            return BSEntidades.MapeoEntidadesDTO(TypeId, CategoryId, EntityId);
        }

        [HttpPost]
        [Route("Delete/{Id}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            return await BSEntidades.ValidarEntidad(Id);
        }
    }
}
