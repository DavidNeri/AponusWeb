using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOInfoPropsComponentes
    {
        [JsonProperty(PropertyName = "nombre", NullValueHandling = NullValueHandling.Ignore)]
        public string? Nombre { get; set; }

        [JsonProperty(PropertyName = "tipo", NullValueHandling = NullValueHandling.Ignore)]
        public string? Tipo { get; set; }

    }
}
