using Aponus_Web_API.Sistema;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class AuditController : Controller
    {
        private readonly SS_Aditorias SsAdutorias;

        public AuditController(SS_Aditorias ssAdutorias)
        {
            SsAdutorias = ssAdutorias;
        }


        [HttpGet]
        [Route("List/{Usuario}/{Accion}")]
        [RequiredPermission("AUDITORIAS","SELECT")]
        public async Task<IActionResult> ObtenerAuditorias(string Usuario, string Accion)
        {
            return await SsAdutorias.ProcesarDatosAuditorias(Usuario, Accion);
        }
    }
}
