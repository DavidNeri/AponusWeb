using Newtonsoft.Json;

namespace Aponus_Web_API.Support.Nombres_Geograficos
{
    public class Paises
    {
        [JsonProperty(PropertyName = "countryName", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryName { get; set; }

        [JsonProperty(PropertyName = "countryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "geonameId", NullValueHandling = NullValueHandling.Ignore)]
        public int GeonameId { get; set; }
        

    }
}
