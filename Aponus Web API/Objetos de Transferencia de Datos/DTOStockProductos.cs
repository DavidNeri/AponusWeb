using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOStockProductos : DTOStockFormateado
    {

        [JsonProperty(Order = 1, PropertyName = "idProducto", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdProducto { get; set; }

        [JsonProperty(Order = 2, PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
        public string IdTipo { get; set; } = string.Empty;

        [JsonProperty(Order = 3, PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdDescripcion { get; set; }

        [JsonProperty(Order = 4, PropertyName = "diametroNominal", NullValueHandling = NullValueHandling.Ignore)]
        public string? DiametroNominal { get; set; }

        [JsonProperty(Order = 5, PropertyName = "tolerancia", NullValueHandling = NullValueHandling.Ignore)]
        public string? Tolerancia { get; set; }

        [JsonProperty(Order = 6, PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
        public string? Cantidad { get; set; }

        [JsonProperty(Order = 7, PropertyName = "precioLista", NullValueHandling = NullValueHandling.Ignore)]
        public string? PrecioLista { get; set; }

        [JsonProperty(Order = 8, PropertyName = "precioFinal", NullValueHandling = NullValueHandling.Ignore)]
        public string? PrecioFinal { get; set; }

        [JsonProperty(Order = 9, PropertyName = "porcentajeGanancia", NullValueHandling = NullValueHandling.Ignore)]
        public string? PorcentajeGanancia { get; set; }

    }
}
