using Newtonsoft.Json;

namespace Aponus_Web_API.Utilidades.Nombres_Geograficos
{
    public class Paises
    {
        [JsonProperty(PropertyName = "countryName", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryName { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "countryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCode { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "geonameId", NullValueHandling = NullValueHandling.Ignore)]
        public int GeonameId { get; set; }


    }
}
