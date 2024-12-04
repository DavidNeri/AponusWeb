using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
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
        [RequiredPermission("ENTIDADES_TIPOS", "INSERT")]
        [RequiredPermission("ENTIDADES_TIPOS", "UPDATE")]
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
        [RequiredPermission("ENTIDADES_CATEGORIAS", "INSERT")]
        [RequiredPermission("ENTIDADES_CATEGORIAS", "UPDATE")]
        [RequiredPermission("ENTIDADES_TIPOS_CATEGORIAS", "INSERT")]
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
        [RequiredPermission("ENTIDADES_CATEGORIAS", "UPDATE")]
        public async Task<IActionResult> EliminarCategoria(int Id)
        {
            return await BSEntidades.CategoriasEntidades().ValidarCategoria(Id);
        }

        [HttpPost]
        [Route("Types/Delete/{Id}")]
        [RequiredPermission("ENTIDADES", "UPDATE")]
        [RequiredPermission("ENTIDADES_TIPOS", "UPDATE")]
        public async Task<IActionResult> EliminarTipo(int Id)
        {
            return await BSEntidades.TiposEntidades().ValidarTipoEntidad(Id);
        }

        [HttpPost]
        [Route("Save")]
        [RequiredPermission("ENTIDADES", "INSERT")]
        [RequiredPermission("ENTIDADES", "UPDATE")]
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
        [RequiredPermission("ENTIDADES", "UPDATE")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            return await BSEntidades.ValidarEntidad(Id);
        }
    }
}
