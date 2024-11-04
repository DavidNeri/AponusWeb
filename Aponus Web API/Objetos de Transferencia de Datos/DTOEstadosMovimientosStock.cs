using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOEstadosMovimientosStock
    {
        [JsonProperty(PropertyName = "idEstadoMovimiento", NullValueHandling = NullValueHandling.Ignore)]
        public int? idEstadoMovimiento { get; set; }

        [JsonProperty(PropertyName = "desripcion", NullValueHandling = NullValueHandling.Ignore)]
        public string Descripcion { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "idEstado", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdEstado { get; set; }
    }
}
