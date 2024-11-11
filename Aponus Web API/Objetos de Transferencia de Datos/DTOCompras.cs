using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOCompras
    {
        [JsonProperty(PropertyName = "idCompra", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdCompra { get; set; }

        [JsonProperty(PropertyName = "idProveedor", NullValueHandling = NullValueHandling.Ignore)]
        public int IdProveedor { get; set; }

        [JsonProperty(PropertyName = "fechaHora", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FechaHora { get; set; }

        [JsonProperty(PropertyName = "idUsuario", NullValueHandling = NullValueHandling.Ignore)]
        public string IdUsuario { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "montoTotal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? SaldoTotal { get; set; }

        [JsonProperty(PropertyName = "saldoPendiente", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? SaldoPendiente { get; set; }

        [JsonProperty(PropertyName = "idEstadoCompra", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdEstadoCompra { get; set; }

        [JsonProperty(PropertyName = "saldoCancelado", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? SaldoCancelado => SaldoTotal ?? 0 - (SaldoPendiente ?? 0);

        [JsonProperty(PropertyName = "usuario", NullValueHandling = NullValueHandling.Ignore)]
        public DTOUsuarios Usuario { get; set; } = new();

        [JsonProperty(PropertyName = "estado", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DTOEstadosCompras Estado { get; set; } = new();

        [JsonProperty(PropertyName = "proveedor", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DTOEntidades Proveedor { get; set; } = new();

        [JsonProperty(PropertyName = "detallesCompra", NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<DTOComprasDetalles> DetallesCompra { get; set; } = new HashSet<DTOComprasDetalles>();

        [JsonProperty(PropertyName = "pagos", NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<DTOPagosCompras> Pagos { get; set; } = new HashSet<DTOPagosCompras>();



    }
}
