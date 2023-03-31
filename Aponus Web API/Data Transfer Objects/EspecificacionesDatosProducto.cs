 using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class EspecificacionesDatosProducto

    {
        [JsonProperty(PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdTipo { get; set; }

        [JsonProperty(PropertyName = "idProducto", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdProducto { get; set; }

        [JsonProperty(PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdDescripcion { get; set; }

        [JsonProperty(PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
        public int? DiametroNominal { get; set; }
       
        [JsonProperty(PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
        public string? Tolerancia{ get; set; }


        [JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
        public int? Cantidad { get; set; }

        [JsonProperty(PropertyName = "precio", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Precio { get; set; }


    }
}
