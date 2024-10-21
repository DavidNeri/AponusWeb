using Aponus_Web_API.Utilidades;
using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class DTOStockFormateado
    {
        [JsonProperty(Order=15, PropertyName = "idInsumo", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdInsumo { get; set; }

        [JsonProperty(Order=16, PropertyName = "NombreInsumo", NullValueHandling = NullValueHandling.Ignore)]
        public string? NombreInsumo { get; set; }

        [JsonProperty(Order=17, PropertyName = "recibido", NullValueHandling = NullValueHandling.Ignore)]
        public string? Recibido { get; set; }

        [JsonProperty(Order=18, PropertyName = "granallado", NullValueHandling = NullValueHandling.Ignore)]
        public string? Granallado { get; set; }

        [JsonProperty(Order=19, PropertyName = "pintura", NullValueHandling = NullValueHandling.Ignore)]
        public string? Pintura { get; set; }

        [JsonProperty(Order=20, PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
        public string? Proceso { get; set; }

        [JsonProperty(Order=21, PropertyName = "moldeado", NullValueHandling = NullValueHandling.Ignore)]
        public string? Moldeado { get; set; }

        [JsonProperty(Order=22, PropertyName = "requerido", NullValueHandling = NullValueHandling.Ignore)]
        public string? Requerido { get; set; }

        [JsonProperty(Order=23, PropertyName = "disponibles", NullValueHandling = NullValueHandling.Ignore)]
        public string? Disponibles { get; set; }

        [JsonProperty(Order=24, PropertyName = "faltantes", NullValueHandling = NullValueHandling.Ignore)]
        public string? Faltantes { get; set; }

        [JsonProperty(Order=25, PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public string? Total { get; set; }

    }
}
