using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOEntidadesCategorias
    {
        [JsonProperty(PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdTipo { get; set; }

        [JsonProperty(PropertyName = "idCategoria", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdCategoria { get; set; }

        [JsonProperty(PropertyName = "nombreCategoria", NullValueHandling = NullValueHandling.Ignore)]
        public string? NombreCategoria { get; set; }

    }
}
