using Newtonsoft.Json;

namespace Aponus_Web_API.Utilidades.Nombres_Geograficos
{
    public class Ciudades
    {
        [JsonProperty(PropertyName = "toponymName", NullValueHandling = NullValueHandling.Ignore)]
        public string ToponymName { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "countryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCode { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "adminCode1", NullValueHandling = NullValueHandling.Ignore)]
        public string AdminCode1 { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "geonameId", NullValueHandling = NullValueHandling.Ignore)]
        public string geonameId { get; set; } = string.Empty;

    }
}
