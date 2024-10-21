using Microsoft.AspNetCore.Mvc;
using Aponus_Web_API.Utilidades.Nombres_Geograficos;
using Newtonsoft.Json;



namespace Aponus_Web_API.Utilidades
{
    public class NombresGeograficos
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly string usuario = "davidcneri";
        internal async Task<IActionResult> ListarPaises()
        {
            try
            {
                var URL = $"http://api.geonames.org/countryInfoJSON?username={usuario}";
                HttpResponseMessage RespuestaHttp = await _httpClient.GetAsync(URL);

                RespuestaHttp.EnsureSuccessStatusCode();

                string Resultado = await RespuestaHttp.Content.ReadAsStringAsync();

                var Respuesta = JsonConvert.DeserializeObject<CountryResponse>(Resultado);

                return new JsonResult(Respuesta);

            }
            catch (Exception EX)
            {

                return new ContentResult()
                {
                    Content= EX.InnerException?.Message ?? EX.Message,
                    ContentType="application/json",
                    StatusCode=400
                };
            }         

        }

        internal async Task<IActionResult> ListarProvincias(int CountryId)
        {
            var URL = $"http://api.geonames.org/childrenJSON?geonameId={CountryId}&username={usuario}";
            HttpResponseMessage RespuestaHttp = await _httpClient.GetAsync(URL);

            RespuestaHttp.EnsureSuccessStatusCode();

            string Resultado = await RespuestaHttp.Content.ReadAsStringAsync();

            var Respuesta = JsonConvert.DeserializeObject<StatesResponse>(Resultado);

            List<Estados_Provincias>? Estados_Provincias = Respuesta?.Geonames;
            
            Estados_Provincias?
                .ForEach(x => x.ToponymName = x.ToponymName
                .Replace(" Province", "")
                .Replace(" State", "")
                .Replace(" Region", "")
                .Replace(" Departament", "")
                .Replace(" Prefecture", "")
                .Replace(" Territory", "")
                .Trim());
            
            return new JsonResult(Estados_Provincias);
        }

        internal async Task<IActionResult> ListarCiudades(string CountryId, string Estado_Provincia_Id )
        {
            var URL = $"http://api.geonames.org/searchJSON?&adminCode1={Estado_Provincia_Id}&country={CountryId}&username={usuario}";
            HttpResponseMessage RespuestaHttp = await _httpClient.GetAsync(URL);
            RespuestaHttp.EnsureSuccessStatusCode();

            string Resultado = await RespuestaHttp.Content.ReadAsStringAsync();

            var Respuesta = JsonConvert.DeserializeObject<CitiesResponse>(Resultado);

            return new JsonResult(Respuesta);

        }

    }
}
