using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTODescripcionComponentes
    {
        [JsonProperty(PropertyName = "idDescripcion", NullValueHandling = NullValueHandling.Ignore)]
        public int IdDescripcion { get; set; } = 0;

        [JsonProperty(PropertyName = "descripcion", NullValueHandling = NullValueHandling.Ignore)]
        public string Descripcion { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "idAlmacenamiento", NullValueHandling = NullValueHandling.Ignore)]
        public string IdAlmacenamiento { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "idFraccionamiento", NullValueHandling = NullValueHandling.Ignore)]
        public string? IdFraccionamiento { get; set; }
    }
}
