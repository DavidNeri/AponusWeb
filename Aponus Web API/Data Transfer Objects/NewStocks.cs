using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class NewStocks
    {
        [JsonProperty(PropertyName = "idInsumo", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdInsumo { get; set; }

        [JsonProperty(PropertyName = "pesoReq", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? PesoReq{ get; set; }

        [JsonProperty(PropertyName = "CantidadReq", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? CantidadReq{ get; set; }

        [JsonProperty(PropertyName = "longReq", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? LongReq { get; set; }

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

        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Total { get; set; }

        [JsonProperty(PropertyName = "faltantes", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Faltantes { get; set; }

        [JsonProperty(PropertyName = "disponibles", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Disponibles { get; set; }
    }
}
