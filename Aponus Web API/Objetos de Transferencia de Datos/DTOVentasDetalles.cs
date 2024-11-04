using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOVentasDetalles
    {
        [JsonProperty(PropertyName = "idVenta", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdVenta { get; set; }

        [JsonProperty(PropertyName = "idProducto", NullValueHandling = NullValueHandling.Ignore)]
        public string IdProducto { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
        public int Cantidad { get; set; }

        [JsonProperty(PropertyName = "precio", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Precio { get; set; }

        public decimal SubTotal => Precio * Cantidad;

    }
}