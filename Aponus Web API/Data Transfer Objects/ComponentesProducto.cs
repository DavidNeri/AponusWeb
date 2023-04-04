using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class ComponentesProducto
    {
        [JsonProperty(PropertyName = "idProducto", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdProducto { get; set; }

        [JsonProperty(PropertyName = "idComponente", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdComponente { get; set; }

        [JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
        public int? Cantidad { get; set; }

        [JsonProperty(PropertyName = "peso", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Peso { get; set; }

        [JsonProperty(PropertyName = "largo", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Largo { get; set; }

    }
}
