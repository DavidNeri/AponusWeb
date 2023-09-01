using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class DTODetallesProducto

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

        [JsonProperty(PropertyName = "precioLista", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PrecioLista { get; set; }

        [JsonProperty(PropertyName = "precioFinal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PrecioFinal { get; set; }

        [JsonProperty(PropertyName = "porcentajeGanancia", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PorcentajeGanancia { get; set; }


    }
}
