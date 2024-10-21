using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOStock
    {
        [JsonProperty(PropertyName = "idInsumo", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdInsumo { get; set; }

        [JsonProperty(PropertyName = "peso", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Peso{ get; set; }

        [JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Cantidad{ get; set; }

        [JsonProperty(PropertyName = "longitud", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Longitud { get; set; }

        [JsonProperty(PropertyName = "recibido", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Recibido { get; set; }

        [JsonProperty(PropertyName = "granallado", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Granallado { get; set; }

        [JsonProperty(PropertyName = "pintura", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Pintura { get; set; }

        [JsonProperty(PropertyName = "moldeado", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Moldeado { get; set; }

        [JsonProperty(PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Proceso { get; set; }

        [JsonProperty(PropertyName = "pendientes", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Pendientes { get; set; }

        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Total { get; set; }

        [JsonProperty(PropertyName = "faltantes", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Faltantes { get; set; }

        [JsonProperty(PropertyName = "disponibles", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Disponibles { get; set; }
    }
}
