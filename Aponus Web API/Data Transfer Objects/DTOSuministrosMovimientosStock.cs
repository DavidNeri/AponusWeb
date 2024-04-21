using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOSuministrosMovimientosStock
    {
        [JsonProperty(PropertyName = "idMovimiento", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdMovimiento { get; set; }

        [JsonProperty(PropertyName = "idSuministro", NullValueHandling = NullValueHandling.Ignore)]
        public string IdSuministro { get; set; }

        [JsonProperty(PropertyName = "nombreSuministro", NullValueHandling = NullValueHandling.Ignore)]
        public string? NombreSuministro { get; set; }  

        [JsonProperty(PropertyName = "valorAnteriorOrigen", NullValueHandling = NullValueHandling.Ignore)]
        public string? ValorAnteriorOrigen { get; set; }

        [JsonProperty(PropertyName = "valorAnteriorDestino", NullValueHandling = NullValueHandling.Ignore)]
        public string? ValorAnteriorDestino { get; set; }

        [JsonProperty(PropertyName = "valorNuevoOrigen", NullValueHandling = NullValueHandling.Ignore)]
        public string? ValorNuevoOrigen { get; set; }

        [JsonProperty(PropertyName = "valorNuevoDestino", NullValueHandling = NullValueHandling.Ignore)]
        public string? ValorNuevoDestino { get; set; }

        [JsonProperty(PropertyName = "cantidad", NullValueHandling = NullValueHandling.Ignore)]
        public string? Cantidad { get; set; }

    }
}
