using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOCuotasCompras
    {
        [JsonProperty(PropertyName = "idCuota", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdCuota { get; set; }

        [JsonProperty(PropertyName = "idCompra", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdVenta { get; set; }

        [JsonProperty(PropertyName = "numeroCuota", NullValueHandling = NullValueHandling.Ignore)]
        public int NumeroCuota { get; set; }

        [JsonProperty(PropertyName = "monto", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Monto { get; set; }

        [JsonProperty(PropertyName = "fechaVencimiento", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime FechaVencimiento { get; set; }

        [JsonProperty(PropertyName = "idEstadoCuota", NullValueHandling = NullValueHandling.Ignore)]
        public int IdEstadoCuota { get; set; }

        [JsonProperty(PropertyName = "fechaPago", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FechaPago { get; set; }

        [JsonProperty(PropertyName = "estadoCuota", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DTOEstadosCuotasCompras? EstadoCuota { get; set; }

        [JsonProperty(PropertyName = "pagos", NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<DTOPagosCompras> Pagos { get; set; } = new HashSet<DTOPagosCompras>();
    }
}
