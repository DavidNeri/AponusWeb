using Aponus_Web_API.Mapping;
using Aponus_Web_API.System;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]

    public class UsersController :ControllerBase
    {
        [HttpGet]
        [Route("Validation/{Usuario}/{Contraseña}")]
        public UsuariosMapping? ValiadarUsuario(string Usuario, string Contraseña) 
        {
            return new Validaciones().ValidarUsuario(Usuario, Contraseña);
        }
    }
}
