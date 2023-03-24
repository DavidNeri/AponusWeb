 using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class EspecificacionesDatosProducto
    {
        [JsonProperty(PropertyName = "idProducto", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdProducto { get; set; }

        [JsonProperty(PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
        public int? DiametroNominal { get; set; }

        [JsonProperty(PropertyName = "toleranciaMinima", NullValueHandling = NullValueHandling.Ignore)]
        public int? ToleranciaMinima { get; set; }

        [JsonProperty(PropertyName = "toleranciaMaxima", NullValueHandling = NullValueHandling.Ignore)]
        public int? ToleranciaMaxima { get; set; }


        [JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
        public int? Cantidad { get; set; }
    }
}
