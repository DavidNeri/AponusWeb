using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class InsumosCuantitativos
    {
        [JsonProperty(PropertyName = "nombre")]
        public string? NombreInsumo { get; set; }

        [JsonProperty(PropertyName = "requerido")]
        public decimal? CantidadRequerida{ get; set; }

        [JsonProperty(PropertyName = "recibido")]
        public int? CantidadRecibida{ get; set; }

        [JsonProperty(PropertyName = "granallado")]
        public int? CantidadGranallado{ get; set; }

        [JsonProperty(PropertyName = "pintura")]
        public int? CantidadPintura{ get; set; }

        [JsonProperty(PropertyName = "proceso")]
        public int? CantidadProceso{ get; set; }




    }
}
