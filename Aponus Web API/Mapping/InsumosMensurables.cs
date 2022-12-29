using Newtonsoft.Json;

namespace Aponus_Web_API.Mapping
{
    public class InsumosMensurables
    {
        [JsonProperty(PropertyName = "nombre")]
        public string? NombreInsumo { get; set; }

        [JsonProperty(PropertyName = "alturaCuerpoPerfil")]
        public decimal? AlturaCuerpoPerfil { get; set; }

        [JsonProperty(PropertyName = "largoRequerido")]
        public decimal? LargoRequerido { get; set; }


        [JsonProperty(PropertyName = "largoStock")]
        public decimal? LargoStock{ get; set; }


        [JsonProperty(PropertyName = "perfil")]
        public int? Perfil { get; set; }

        //[JsonProperty(PropertyName = "espesor")]
        // public int? Espesor { get; set; }

        [JsonProperty(PropertyName = "recibido")]
        public int? CantidadRecibido { get; set; }

       
    }
}
