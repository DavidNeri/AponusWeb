using Newtonsoft.Json;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTODescripcionComponentes
    {
        [JsonProperty(PropertyName = "idDescripcion")]
        public int IdDescripcion { get; set; } = 0;

        [JsonProperty(PropertyName = "nombreDescripcion")]
        public string NombreDescripcion { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "idAlmacenamiento")]
        public string IdAlmacenamiento { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "idFraccionamiento")]
        public string? IdFraccionamiento { get; set; }
    }
}
