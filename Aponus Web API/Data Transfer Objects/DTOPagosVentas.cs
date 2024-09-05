using Aponus_Web_API.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOPagosVentas
    {
        [JsonProperty(PropertyName = "idPago", NullValueHandling = NullValueHandling.Ignore)]
        public int IdPago { get; set; }

        [JsonProperty(PropertyName = "idVenta", NullValueHandling = NullValueHandling.Ignore)]
        public int IdVenta { get; set; }

        [JsonProperty(PropertyName = "idMedioPago", NullValueHandling = NullValueHandling.Ignore)]
        public int IdMedioPago { get; set; }

        [JsonProperty(PropertyName = "monto", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Monto { get; set; }

        [JsonProperty(PropertyName = "fechaPago", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FechaPago { get; set; }

        [JsonProperty(PropertyName = "medioPago", NullValueHandling = NullValueHandling.Ignore)]
        public DTOMediosPago? MedioPago { get; set; }

    }
}