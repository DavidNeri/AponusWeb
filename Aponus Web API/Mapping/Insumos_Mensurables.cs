using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class Insumos_Mensurables
    {
        [JsonProperty(PropertyName = "idDescripcion"), JsonIgnore]
        public int? IdDescripcion { get; set; }

        [JsonProperty(PropertyName = "largo")]
        public decimal? Largo { get; set; }

        [JsonProperty(PropertyName = "espesor")]
        public decimal? Espesor { get; set; }


        [JsonProperty(PropertyName = "perfil")]
        public int? Perfil { get; set; }

        [JsonProperty(PropertyName = "recibido")]
        public decimal? Recibido { get; set; }

        [JsonProperty(PropertyName = "proceso")]
        public decimal? Proceso { get; set; }
    }
}
