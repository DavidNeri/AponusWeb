using Aponus_Web_API.Negocio;
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
        public async Task<IActionResult> ObtenerAuditorias(string Usuario, string Accion)
        {
            return await SsAdutorias.ProcesarDatosAuditorias(Usuario, Accion);
        }
    }
}
