using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class ColumnasInsumosMensurables

    {
        [JsonProperty(PropertyName = "largo", NullValueHandling = NullValueHandling.Ignore)]
        public string? Largo { get; set; } = "Largo (m)";

        [JsonProperty(PropertyName = "ancho", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ancho { get; set; } = "Ancho (mm)";
       

        [JsonProperty(PropertyName = "Perfil", NullValueHandling = NullValueHandling.Ignore)]
        public string? Perfil { get; set; } = "Perfil";

        [JsonProperty(PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
        public string? Proceso { get; set; } = "Cant. Proceso (Ud.)";



    }
}
