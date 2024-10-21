using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOCategorias : DTODescripciones
    {
        [JsonProperty(PropertyName = "idTipo", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdTipo{ get; set; }

        [JsonProperty(PropertyName = "descripcionTipo", NullValueHandling = NullValueHandling.Ignore)]
        public string? DescripcionTipo{ get; set; }
    }
}
