using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class DTOStocks
    {
        [JsonProperty(PropertyName = "idInsumo", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdInsumo { get; set; }

        [JsonProperty(PropertyName = "NombreInsumo", NullValueHandling = NullValueHandling.Ignore)]
        public string? NombreInsumo { get; set; }

        [JsonProperty(PropertyName = "requerido", NullValueHandling = NullValueHandling.Ignore)]
        public string? Requerido { get; set; }

        [JsonProperty(PropertyName = "recibido", NullValueHandling = NullValueHandling.Ignore)]
        public string? Recibido { get; set; }

        [JsonProperty(PropertyName = "granallado", NullValueHandling = NullValueHandling.Ignore)]
        public string? Granallado { get; set; }

        [JsonProperty(PropertyName = "pintura", NullValueHandling = NullValueHandling.Ignore)]
        public string? Pintura { get; set; }

        [JsonProperty(PropertyName = "moldeado", NullValueHandling = NullValueHandling.Ignore)]
        public string? Moldeado { get; set; }

        [JsonProperty(PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
        public string? Proceso { get; set; }

        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public string? Total { get; set; }

        [JsonProperty(PropertyName = "faltantes", NullValueHandling = NullValueHandling.Ignore)]
        public string? Faltantes { get; set; }

        [JsonProperty(PropertyName = "disponibles", NullValueHandling = NullValueHandling.Ignore)]
        public string? Disponibles { get; set; }
    }
}
