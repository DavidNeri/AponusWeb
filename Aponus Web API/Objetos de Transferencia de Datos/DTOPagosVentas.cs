using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
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
        public DateTime? Fecha { get; set; }

        [JsonProperty(PropertyName = "medioPago", NullValueHandling = NullValueHandling.Ignore)]
        public DTOMediosPago? MedioPago { get; set; }

    }
}