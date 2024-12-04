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
            var ClaimsUsuario = context.HttpContext.User.Claims;

            var permisos = ClaimsUsuario.FirstOrDefault(x=>x.Type == "Permisos")?.Value;

            if (string.IsNullOrEmpty(permisos) || !permisos.Split(',').Contains($"{_tabla}:{_Atributo}"))
            {
                context.Result = new ForbidResult("No tienes permisos para realizar esta acción");
            }
        }
    }

}
