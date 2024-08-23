using Aponus_Web_API.Mapping;
using Aponus_Web_API.System;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]

    public class UsersController :ControllerBase
    {
        [HttpPost]
        [Route("Validation")]
        public DTOUsuarios? ValiadarUsuario(DTOUsuarios Usuario) 
        {
            return new Validaciones().ValidarUsuario(Usuario);
        }

        
    }
}
