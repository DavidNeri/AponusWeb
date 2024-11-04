using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOMediosPago
    {
        [JsonProperty(PropertyName = "idMedioPago", NullValueHandling = NullValueHandling.Ignore)]
        public int IdMedioPago { get; set; }

        [JsonProperty(PropertyName = "codigoMPago", NullValueHandling = NullValueHandling.Ignore)]
        public string? CodigoMPago { get; set; }

        [JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
        public string Descripcion { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "idEstado", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdEstado { get; set; }
    }
}
