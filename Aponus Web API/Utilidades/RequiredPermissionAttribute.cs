using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aponus_Web_API.Utilidades
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]

    public class RequiredPermissionAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _tabla;
        private readonly string _Atributo;

        public RequiredPermissionAttribute(string tabla, string atributo)
        {
            _tabla = tabla;
            _Atributo = atributo;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var RolUsuario = context.HttpContext.User.FindFirst("Rol")?.Value;
            var CambiarContraseña = context.HttpContext.User.FindFirst("CambiarContraseña")?.Value;

            if (string.IsNullOrEmpty(RolUsuario) || (CambiarContraseña != null && CambiarContraseña.Equals("True")))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var permisos = ObtenerPermisosDB(context, RolUsuario);

            if (!permisos.Contains($"{_tabla}:{_Atributo}"))
            {
                context.Result = new ForbidResult("No tienes permisos para realizar esta acción");
            }

        }

        private List<string> ObtenerPermisosDB(AuthorizationFilterContext context, string RolUsuario)
        {
            var services = context.HttpContext.RequestServices;
            var aponusContext = services.GetRequiredService<AponusContext>();
            var adUsuarios = services.GetRequiredService<AD_Usuarios>();

            return aponusContext.asignacionRoles
                .Where(p => p.Beneficiario == RolUsuario)
                .Select(p => $"{p.NombreTabla}:{p.Atributo}")
                .ToList();
        }
    }

}
