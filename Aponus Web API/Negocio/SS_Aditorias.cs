using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Modelos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Aponus_Web_API.Negocio
{
    public class SS_Aditorias
    {
        private readonly AD_Auditorias AdAuditorias;

        public SS_Aditorias(AD_Auditorias adAuditorias)
        {
            AdAuditorias = adAuditorias;
        }

        internal async Task<IActionResult> ProcesarDatosAuditorias(string Usuario, string Accion)
        {
            var (ListadoAuditorias, error) = await AdAuditorias.Listar();
            if (error != null)
                return new ContentResult()
                {
                    Content = error.InnerException?.Message ?? error.Message,
                    ContentType  = "application/json",
                    StatusCode = 400,
                };

            if (!Usuario.Equals("0"))
                ListadoAuditorias=ListadoAuditorias!.Where(x => x.Usuario.Equals(Usuario));
            if(!Accion.Equals("0"))
                ListadoAuditorias=ListadoAuditorias!.Where(x => x.Accion.Equals(Accion));

            var Resultado = ListadoAuditorias!
                .Select(a => new DTOAuditorias()
                {
                    Accion = a.Accion,
                    Fecha = a.Fecha,
                    IdAuditoria = a.IdAuditoria,
                    IdRegistro = a.IdRegistro,
                    Tabla = a.Tabla,
                    Usuario = a.Usuario,
                    ValoresNuevos = !string.IsNullOrEmpty(a.ValoresNuevos)
                    ? JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(a.ValoresNuevos)?
                        .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.ValueKind == JsonValueKind.Number ?$"{kvp.Key}; {(object)kvp.Value.GetDecimal()}" :
                                        kvp.Value.ValueKind == JsonValueKind.String ? $"{kvp.Key}; {(object?)kvp.Value.GetString()}" :
                                        kvp.Value.ValueKind == JsonValueKind.True || kvp.Value.ValueKind == JsonValueKind.False ? $"{kvp.Key}; {(object)kvp.Value.GetBoolean()}" :
                                        (object?)null)
                        : null,

                    ValoresPrevios = !string.IsNullOrEmpty(a.ValoresPrevios)
                        ? JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(a.ValoresPrevios)?
                            .ToDictionary(
                                kvp => kvp.Key,
                                kvp => kvp.Value.ValueKind == JsonValueKind.Number ? $"{kvp.Key}; {(object)kvp.Value.GetDecimal()}" :
                                        kvp.Value.ValueKind == JsonValueKind.String ? $"{kvp.Key}; {(object?)kvp.Value.GetString()}" :
                                        kvp.Value.ValueKind == JsonValueKind.True || kvp.Value.ValueKind == JsonValueKind.False ? $"{kvp.Key}; {(object)kvp.Value.GetBoolean()}" :
                                        (object?)null)
                            : null
                })
                .ToList();
            
            
            return new JsonResult(Resultado);
        }
    }
}
