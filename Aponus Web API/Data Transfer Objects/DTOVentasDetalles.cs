using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOVentasDetalles
    {
        [JsonProperty(PropertyName = "idVenta", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdVenta { get; set; }

        [JsonProperty(PropertyName = "idProducto", NullValueHandling = NullValueHandling.Ignore)]
        public string IdProducto { get; set; }

        [JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
        public int Cantidad { get; set; }

        [JsonProperty(PropertyName = "precio", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Precio { get; set; }

        public decimal SubTotal => Precio * Cantidad;

        [JsonProperty(PropertyName = "datosProducto", NullValueHandling = NullValueHandling.Ignore)]
        public DTODatosProducto? datosProducto { get; set; }
    }
}