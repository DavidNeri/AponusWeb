using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using System.Runtime;

namespace Aponus_Web_API.Support.Servicios_BIN
{
    public class IdentificacionesBancarias
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
