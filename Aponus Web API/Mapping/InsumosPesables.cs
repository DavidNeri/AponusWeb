using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class InsumosPesables
    {
        [JsonProperty(PropertyName = "nombre")]
        public string? NombreInsumo { get; set; }

        [JsonProperty(PropertyName = "requerido")]
        public string? PesoRequerido { get; set; }

        [JsonProperty(PropertyName = "recibdo")]
        public string? CantidadRecibida { get; set; }

        [JsonProperty(PropertyName = "pintura")]
        public string? CantidadPintura { get; set; }

        [JsonProperty(PropertyName = "proceso")]
        public string? CantidadProceso { get; set; }
    }
}

