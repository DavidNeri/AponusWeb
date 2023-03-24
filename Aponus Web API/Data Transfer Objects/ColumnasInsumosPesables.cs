using Newtonsoft.Json;

namespace Aponus_Web_API.Data_Transfer_objects
{
    public class ColumnasInsumosPesables
    {


        [JsonProperty(PropertyName = "diametro", NullValueHandling = NullValueHandling.Ignore)]
        public string? Diametro { get; set; } = "Diametro (mm)";

        [JsonProperty(PropertyName = "altura", NullValueHandling = NullValueHandling.Ignore)]
        public string? Altura { get; set; } = "Altura";

        [JsonProperty(PropertyName = "recibido", NullValueHandling = NullValueHandling.Ignore)]

        public string? Recibido { get; set; } = "Cant. Recibida (Kg)";
       

        [JsonProperty(PropertyName = "pintura", NullValueHandling = NullValueHandling.Ignore)]
        public string? Pintura { get; set; } = "Cant. Pintura (Kg)";

     
        [JsonProperty(PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
        public string? Proceso { get; set; } = "Cant. Proceso (Kg)";      
       
     
    }
}

