using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class Insumos
    {
        [JsonProperty(PropertyName = "nombre")]
        public string? Nombre { get; set; }

        [JsonProperty(PropertyName = "requerido")]
        public string? Requerido { get; set; }

        [JsonProperty(PropertyName = "recibdo")]
        public string? Recibido { get; set; }

        [JsonProperty(PropertyName = "granallado")]
        public string? Granallado { get; set; }     

        [JsonProperty(PropertyName = "pintura")]
        public string? Pintura { get; set; }

        [JsonProperty(PropertyName = "proceso")]   
        public string? Proceso { get; set; }

        [JsonProperty(PropertyName = "moldeado")]
        public string? Moldeado { get; set; }

        [JsonProperty(PropertyName = "total")]
        public string? Total { get; set; }

        [JsonProperty(PropertyName = "faltantes")]
        public string? Faltantes { get; set; }
    }
}

