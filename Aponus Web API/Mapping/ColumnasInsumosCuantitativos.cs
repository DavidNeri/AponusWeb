using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class ColumnasInsumosCuantitativos
    {
        [JsonProperty(PropertyName = "espesor", NullValueHandling = NullValueHandling.Ignore)]
        public string? Espesor { get; set; } = "Espesor";

        [JsonProperty(PropertyName = "perfil", NullValueHandling = NullValueHandling.Ignore)]
        public string? Perfil { get; set; } = "Perfil";
                
        [JsonProperty(PropertyName = "diametro", NullValueHandling = NullValueHandling.Ignore)]
        public string? Diametro { get; set; } = "Diámetro";

        [JsonProperty(PropertyName = "altura", NullValueHandling = NullValueHandling.Ignore)]
        public string? Altura { get; set; } = "Altura";

        [JsonProperty(PropertyName = "toleranciaMinima", NullValueHandling = NullValueHandling.Ignore)]
        public string? ToleranciaMinina { get; set; } = "Tolerancia mínima";

        [JsonProperty(PropertyName = "toleranciaMaxima", NullValueHandling = NullValueHandling.Ignore)]
        public string? ToleranciaMaxima { get; set; } = "Tolerancia máxima";

        [JsonProperty(PropertyName = "requerido", NullValueHandling = NullValueHandling.Ignore)]
        public string? Requerido { get; set; } = "Cant. Requerida (Ud.)";

        [JsonProperty(PropertyName = "recibido", NullValueHandling = NullValueHandling.Ignore)]
        public string? Recibido { get; set; } = "Cant. Recibida (Ud.)";

        [JsonProperty(PropertyName = "granallado", NullValueHandling = NullValueHandling.Ignore)]
        public string? Granallado { get; set; } = "Cant. Granallado (Ud.)";

        [JsonProperty(PropertyName = "pintura", NullValueHandling = NullValueHandling.Ignore)]
        public string? Pintura { get; set; } = "Cant. Pintura (Ud.)";

        [JsonProperty(PropertyName = "moldeado", NullValueHandling = NullValueHandling.Ignore)]
        public string? Moldeado { get; set; } = "Cant. Moldeada (Ud.)";

        [JsonProperty(PropertyName = "proceso", NullValueHandling = NullValueHandling.Ignore)]
        public string? Proceso { get; set; } = "Cant. Proceso (Ud)";

    }
}
