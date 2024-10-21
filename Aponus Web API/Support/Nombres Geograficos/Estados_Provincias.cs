using Newtonsoft.Json;

namespace Aponus_Web_API.Support.Nombres_Geograficos
{
    public class Estados_Provincias
    {
        [JsonProperty(PropertyName = "toponymName", NullValueHandling = NullValueHandling.Ignore)]
        public string ToponymName { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "geonameId", NullValueHandling = NullValueHandling.Ignore)]
        public string GeonameId { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "countryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string countryCode { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "adminCode1", NullValueHandling = NullValueHandling.Ignore)]
        public string adminCode1 { get; set; } = string.Empty;





    }
}
