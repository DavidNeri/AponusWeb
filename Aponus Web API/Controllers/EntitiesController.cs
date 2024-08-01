using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class EntitiesController : ControllerBase
    {
        [HttpGet]
        [Route("Types/List")]
        public async Task<IActionResult> ListarTiposEntidades()
        {
            return await BS_Entidades.Tipos.Listar();
        }

        [HttpGet]
        [Route("Categories/List/{IdTipo?}")]

        public async Task<IActionResult> ListarCategoriasEntidades(int? IdTipo)
        {
            return await BS_Entidades.Categorias.Listar(IdTipo);
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
            } else
            {
                return await BS_Entidades.Tipos.Guardar(TipoEntidad);
            }
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
                return await BS_Entidades.Categorias.Guardar(NuevaCategoria);
            }
        }
        [HttpPost]
        [Route("Categories/Delete/{Id}")]
        public IActionResult EliminarCategoria(int Id)
        {
            return BS_Entidades.Categorias.Eliminar(Id);
        }

        [HttpPost]
        [Route("Types/Delete/{Id}")]
        public IActionResult EliminarTipo(int Id)
        {
            return BS_Entidades.Tipos.Eliminar(Id);
        }
        

        [HttpPost]
        [Route("Save")]
        public IActionResult Nuevo(DTOEntidades Entidad)
        {
            return BS_Entidades.Guardar(Entidad);
        }

        // 

        [HttpPost]
        [Route("Delete/{Id}")]
        public IActionResult Eliminar(int Id)
        {
            return BS_Entidades.Eliminar(Id);
        }

        [HttpGet]
        [Route("List/{typeId?}/{CategoryId?}/{EntityId?}")]
        public async Task<IActionResult> Listar(int? TypeId, int?CategoryId, int? EntityId)
        {
            return BS_Entidades.Listar(TypeId, CategoryId, EntityId);
        }

        

       

   

       
    }
}
