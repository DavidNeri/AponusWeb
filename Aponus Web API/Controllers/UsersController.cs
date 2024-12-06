using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Systema;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SS_Usuarios _Usuarios;
        public UsersController(SS_Usuarios usuarios)
        {
            _Usuarios = usuarios;
        }

        [HttpPost]
        [Route("logIn")]
        public async Task<IActionResult> IniciarSesion(DTOUsuarios Usuario)
        {
            return await _Usuarios.ValidarUsuario(Usuario);
        }

        [HttpPost]
        [Route("signIn")]
        public async Task<IActionResult> NuevoAcceso(DTOUsuarios Usuario)
        {
            if (string.IsNullOrEmpty(Usuario.Usuario) || string.IsNullOrEmpty(Usuario.Contraseña) || Usuario.idRol == null)
            {
                return new ContentResult()
                {
                    Content = "Faltan Datos",
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }
            else
            {
                return await _Usuarios.ProcesarDatos(Usuario);
            }
        }

        [HttpPost]
        [Route("roles/list")]

        public async Task<IActionResult> ObtenerPerfiles()
        {
            return await _Usuarios.MapeoRolesDTO();
        }
    }
}
