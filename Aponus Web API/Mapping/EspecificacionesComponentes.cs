using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class EspecificacionesComponentes : Stocks
    {
        [JsonProperty(PropertyName = "idDescripcion"), JsonIgnore]
        public int? IdDescripcion { get; set; }

        [JsonProperty(PropertyName = "idinsumo" , NullValueHandling = NullValueHandling.Ignore)]
        public string? Idinsumo { get; set; }

        [JsonProperty(PropertyName = "largo" , NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Largo { get; set; }

        [JsonProperty(PropertyName = "espesor" , NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Espesor { get; set; }

        [JsonProperty(PropertyName = "perfil" , NullValueHandling = NullValueHandling.Ignore)]
        public int? Perfil { get; set; }

        [JsonProperty(PropertyName = "diametro" , NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Diametro { get; set; }

        [JsonProperty(PropertyName = "Altura" , NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Altura { get; set; }

        [JsonProperty(PropertyName = "toleranciaMinima" , NullValueHandling = NullValueHandling.Ignore)]
        public int? ToleranciaMinina { get; set; }

        [JsonProperty(PropertyName = "toleranciaMaxima" , NullValueHandling = NullValueHandling.Ignore)]
        public int? ToleranciaMaxima { get; set; }
    }
}
