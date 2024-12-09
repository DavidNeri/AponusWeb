using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOPagosCompras
    {
        [JsonProperty(PropertyName = "idPago", NullValueHandling = NullValueHandling.Ignore)]
        public int IdPago { get; set; }

        [JsonProperty(PropertyName = "idCompra", NullValueHandling = NullValueHandling.Ignore)]
        public int IdCompra { get; set; }

        [JsonProperty(PropertyName = "idCuota", NullValueHandling = NullValueHandling.Ignore)]
        public int IdCuota{ get; set; }

        [JsonProperty(PropertyName = "idMedioPago", NullValueHandling = NullValueHandling.Ignore)]
        public int IdMedioPago { get; set; }

        [JsonProperty(PropertyName = "idEntidadPago", NullValueHandling = NullValueHandling.Ignore)]
        public int IdEntidadPago{ get; set; }

        [JsonProperty(PropertyName = "monto", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Monto { get; set; }

        [JsonProperty(PropertyName = "fecha", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Fecha { get; set; }

        [JsonProperty(PropertyName = "medioPago", NullValueHandling = NullValueHandling.Ignore)]
        public DTOMediosPago MedioPago { get; set; } = new(); 

        [JsonProperty(PropertyName = "entidadesPago", NullValueHandling = NullValueHandling.Ignore)]
        public DTOEntidadesPago EntidadesPago { get; set; } = new();

    }
}
