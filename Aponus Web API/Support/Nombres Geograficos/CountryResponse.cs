using Newtonsoft.Json;

namespace Aponus_Web_API.Support.Nombres_Geograficos
{
    public class CountryResponse
    {
        [JsonProperty(PropertyName = "geonames", NullValueHandling = NullValueHandling.Ignore)]
        public List<Paises> Geonames {  get; set; }

    }
}
