using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class ColumnasInsumosPesables
    {


        [JsonProperty(PropertyName = "diametro", NullValueHandling = NullValueHandling.Ignore)]
        public string? Diametro { get; set; } = "Diametro (mm)";

        [JsonProperty(PropertyName = "altura", NullValueHandling = NullValueHandling.Ignore)]
        public string? Altura { get; set; } = "Altura";

        [JsonProperty(PropertyName = "recibido", NullValueHandling = NullValueHandling.Ignore)]

        public string? KgRecibido { get; set; } = "Cant. Recibida (Kg)";
       

        [JsonProperty(PropertyName = "pintura", NullValueHandling = NullValueHandling.Ignore)]
        public string? KgPintura { get; set; } = "Cant. Pintura (Kg)";

     
        [JsonProperty(PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
        public string? KgPoceso { get; set; } = "Cant. Proceso (Kg)";      
       
        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public string? Total { get; set; } = "Total (Kg)";

        [JsonProperty(PropertyName = "faltantes", NullValueHandling = NullValueHandling.Ignore)]
        public string? UFaltantes { get; set; } = "Faltantes (Kg)";
    }
}

