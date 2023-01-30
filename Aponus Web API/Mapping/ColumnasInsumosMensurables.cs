using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class ColumnasInsumosMensurables

    {
        [JsonProperty(PropertyName = "largo", NullValueHandling = NullValueHandling.Ignore)]
        public string? Diametro { get; set; } = "Largo (cm)";

        [JsonProperty(PropertyName = "ancho", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ancho { get; set; } = "Ancho (mm)";
       

        [JsonProperty(PropertyName = "Perfil", NullValueHandling = NullValueHandling.Ignore)]
        public string? Espesor { get; set; } = "Perfil";

        [JsonProperty(PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
        public string? Poceso { get; set; } = "Cant. Proceso (m)";



    }
}
