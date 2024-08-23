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

        [JsonProperty(PropertyName = "cantidadCuotas", NullValueHandling = NullValueHandling.Ignore)]
        public int? CantidadCuotas { get; set; }

        [JsonProperty(PropertyName = "cantidadCuotasCanceladas", NullValueHandling = NullValueHandling.Ignore)]
        public int? CantidadCuotasCanceladas { get; set; }

        [JsonProperty(PropertyName = "subtotal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Subtotal { get; set; }

        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Total { get; set; }

        [JsonProperty(PropertyName = "subtotalCancelado", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? SubtotalCancelado { get; set; }

        [JsonProperty(PropertyName = "subtotalPendiente", NullValueHandling = NullValueHandling.Ignore)]
        public decimal SubtotalPendiente { get; set; }

        [JsonProperty(PropertyName = "cantidadCuotasPendientes", NullValueHandling = NullValueHandling.Ignore)]
        public decimal CantidadCuotasPendientes => CantidadCuotas ?? 0 - CantidadCuotasCanceladas ?? 0;

        [JsonProperty(PropertyName = "medioPago", NullValueHandling = NullValueHandling.Ignore)]
        public DTOMediosPago? MedioPago { get; set; } = new();

        [JsonProperty(PropertyName = "venta", NullValueHandling = NullValueHandling.Ignore)]
        public DTOVentas? Venta = new();
    }
}