using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Aponus_Web_API.Utilidades.Servicios_BIN
{
    public class UTL_IdentificacionesBancarias
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        internal async Task<IActionResult> ObtenerDatosTarjeta(string BIN)
        {
            string URL = $"https://lookup.binlist.net/{BIN}";

            HttpResponseMessage Respuesta = await _httpClient.GetAsync(URL);

            Respuesta.EnsureSuccessStatusCode();
            string BINListJson = await Respuesta.Content.ReadAsStringAsync();

            var binInfo = JsonConvert.DeserializeObject<BINInfo>(BINListJson);

            return new JsonResult(binInfo);


        }
    }
}
