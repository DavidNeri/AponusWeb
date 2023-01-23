using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class Insumos : Stocks
    {
        [JsonProperty(PropertyName = "nombre")]
        public string? Nombre { get; set; }

       
    }
}

