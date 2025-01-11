using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOVentas
    {
        [JsonProperty(PropertyName = "idVenta", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdVenta { get; set; }

        [Required(ErrorMessage = "El campo 'Cliente' es obligatorio"), JsonProperty(PropertyName = "idCliente", NullValueHandling = NullValueHandling.Ignore)]
        public int IdCliente { get; set; }

        [JsonProperty(PropertyName = "fechaHora", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FechaHora { get; set; }

        [Required(ErrorMessage = "El campo 'Usuario' es obligatorio"), JsonProperty(PropertyName = "idUsuario", NullValueHandling = NullValueHandling.Ignore)]
        public string IdUsuario { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "montoTotal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal MontoTotal { get; set; } = 0;

        [JsonProperty(PropertyName = "saldoPendiente", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? SaldoPendiente { get; set; }

        [JsonProperty(PropertyName = "idEstadoVenta", NullValueHandling = NullValueHandling.Ignore)]
        public int IdEstadoVenta { get; set; }

        [JsonProperty(PropertyName = "cliente", NullValueHandling = NullValueHandling.Ignore)]
        public DTOEntidades? Cliente { get; set; }

        [JsonProperty(PropertyName = "detallesVenta", NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<DTOVentasDetalles>? DetallesVenta { get; set; }

        [JsonProperty(PropertyName = "pagos", NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<DTOPagosVentas>? Pagos { get; set; }

        [JsonProperty(PropertyName = "cuotas", NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<DTOCuotasVentas>? Cuotas { get; set; }

        [JsonProperty(PropertyName = "estado", NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<DTOEstadosVentas>? Estado { get; set; }

        [JsonProperty(PropertyName = "archivos", NullValueHandling = NullValueHandling.Ignore)]
        public List<IFormFile>? Archivos { get; set; }

        [JsonProperty(PropertyName = "infoArchivos", NullValueHandling = NullValueHandling.Ignore)]
        public List<DTOArchivosVentas>? infoArchivos { get; set; }


    }
}
