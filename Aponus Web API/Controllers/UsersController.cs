using Aponus_Web_API.Mapping;
using Aponus_Web_API.Systema;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class UsersController :ControllerBase
    {
        private readonly SS_Usuarios _Usuarios;
        public UsersController(SS_Usuarios usuarios)
        {
            _Usuarios = usuarios;
        }

        [HttpPost]
        [Route("Validation")]
        public DTOUsuarios? ValiadarUsuario(DTOUsuarios Usuario) 
        {
            return _Usuarios.ValidarUsuario(Usuario);
        }

        [HttpPost]
        [Route("New")]
        public async Task<IActionResult> Nuevo(DTOUsuarios Usuario)
        {
            if (string.IsNullOrEmpty(Usuario.Usuario) || string.IsNullOrEmpty(Usuario.Contraseña) || Usuario.IdPerfil == null)
            {
                return new ContentResult()
                {
                    Content="Faltan Datos",
                    ContentType="application/json",
                    StatusCode=400
                };
            }else
            {
                return await _Usuarios.NuevoUsuario(Usuario);
            }
        }

        
    }
}
