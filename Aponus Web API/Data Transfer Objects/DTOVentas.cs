using Aponus_Web_API.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOVentas
    {
        [JsonProperty(PropertyName = "idVenta", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdVenta { get; set; }

        [Required(ErrorMessage ="El campo 'Cliente' es obligatorio"), JsonProperty(PropertyName = "idCliente", NullValueHandling = NullValueHandling.Ignore)]
        public int IdCliente { get; set; }

        [JsonProperty(PropertyName = "fechaHora", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FechaHora { get; set; }

        [Required(ErrorMessage = "El campo 'Usuario' es obligatorio"), JsonProperty(PropertyName = "idUsuario", NullValueHandling = NullValueHandling.Ignore)]
        public string IdUsuario { get; set; }

        [JsonProperty(PropertyName = "idEstadoVenta", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdEstadoVenta { get; set; }

        [JsonProperty(PropertyName = "monto", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Monto { get; set; } = 0;

        [JsonProperty(PropertyName = "saldoCancelado", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? SaldoCancelado { get; set; }

        [JsonProperty(PropertyName = "saldoPendiente", NullValueHandling = NullValueHandling.Ignore)]
        public decimal SaldoPendiente => Monto - (SaldoCancelado ?? 0);

        [JsonProperty(PropertyName = "cliente", NullValueHandling = NullValueHandling.Ignore)]
        public DTOEntidades Cliente { get; set; } = new DTOEntidades();

        [JsonProperty(PropertyName = "detallesVenta", NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<DTOVentasDetalles>? DetallesVenta { get; set; } = new HashSet<DTOVentasDetalles>();

        [JsonProperty(PropertyName = "pagos", NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<DTOPagosVentas>? Pagos { get; set; } = new HashSet<DTOPagosVentas>();


        [JsonProperty(PropertyName = "cuotas", NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<DTOCuotasVentas>? Cuotas { get; set; } = new HashSet<DTOCuotasVentas>();

    }
}
