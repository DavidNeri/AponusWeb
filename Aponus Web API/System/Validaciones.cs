﻿using Aponus_Web_API.Acceso_a_Datos.Validaciones;
using Aponus_Web_API.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.System
{
    public class Validaciones
    {
        internal UsuariosMapping? ValidarUsuario(UsuariosMapping Usuario )
        {
            return new Login().Validar(Usuario);

        }
    }
}