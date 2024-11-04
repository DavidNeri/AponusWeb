using Newtonsoft.Json;

namespace Aponus_Web_API.Utilidades.Nombres_Geograficos
{
    public class CountryResponse
    {
        [JsonProperty(PropertyName = "geonames", NullValueHandling = NullValueHandling.Ignore)]
        public List<Paises> Geonames { get; set; } = new List<Paises>();

    }
}
