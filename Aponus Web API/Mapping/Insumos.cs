using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class Insumos : Stocks
    {
        [JsonProperty(PropertyName = "idInsumo", NullValueHandling=NullValueHandling.Ignore)]
        public string? IdInsumo { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string? Nombre { get; set; }

       
    }
}

