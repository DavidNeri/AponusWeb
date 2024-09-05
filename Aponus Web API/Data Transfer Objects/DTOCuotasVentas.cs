using Aponus_Web_API.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOCuotasVentas
    {
        [JsonProperty(PropertyName = "idCuota", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdCuota { get; set; }

        [JsonProperty(PropertyName = "idVenta", NullValueHandling = NullValueHandling.Ignore)]
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
        public virtual DTOEstadosCuotasVentas? EstadoCuota { get; set; }
    }
}