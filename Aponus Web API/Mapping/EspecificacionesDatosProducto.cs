using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class EspecificacionesDatosProducto
    {
        [JsonProperty(PropertyName = "idProducto")]
        public string? IdProducto { get; set; }

        [JsonProperty(PropertyName = "toleranciaMaxima")]
        public int? ToleranciaMaxima { get; set; }

        [JsonProperty(PropertyName = "toleranciaMinima")]
        public int? ToleranciaMinima { get; set; }

        [JsonProperty(PropertyName = "stock")]
        public int? Stock { get; set; }
    }
}
