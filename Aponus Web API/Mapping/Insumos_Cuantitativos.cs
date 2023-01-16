using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class Insumos_Cuantitativos
    {
        [JsonProperty(PropertyName = "idDescripcion"), JsonIgnore]
        public int? IdDescripcion { get; set; }

        [JsonProperty(PropertyName = "diametro")]
        public decimal? Diametro { get; set; }

        [JsonProperty(PropertyName = "Altura")]
        public decimal? Altura { get; set; }

        [JsonProperty(PropertyName = "toleranciaMinima")]
        public int? ToleranciaMimina { get; set; }

        [JsonProperty(PropertyName = "toleranciaMaxima")]
        public int? ToleranciaMaxima { get; set; }

        [JsonProperty(PropertyName = "perfil")]
        public int? Perfil { get; set; }

        [JsonProperty(PropertyName = "espesor")]
        public decimal? Espesor { get; set; }

        [JsonProperty(PropertyName = "recibido")]
        public int? Recibido { get; set; }

        [JsonProperty(PropertyName = "granallado")]
        public int? Granallado { get; set; }

        [JsonProperty(PropertyName = "pintura")]
        public int? Pintura { get; set; }

        [JsonProperty(PropertyName = "moldeado")]
        public int? Moldeado { get; set; }

        [JsonProperty(PropertyName = "proceso")]
        public int? Proceso { get; set; }


    }
}
