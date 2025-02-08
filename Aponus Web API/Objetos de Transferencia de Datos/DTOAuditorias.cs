using System.Text.Json.Serialization;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOAuditorias
    {
        [JsonPropertyName("idAuditoria")]
        public int IdAuditoria { get; set; }

        [JsonPropertyName("tabla")]
        public string Tabla { get; set; } = "";

        [JsonPropertyName("idRegistro")]
        public string IdRegistro { get; set; } = "";

        [JsonPropertyName("Accion")]
        public string Accion { get; set; } = "";

        [JsonPropertyName("Usuario")]
        public string Usuario { get; set; } = "";

        [JsonPropertyName("Fecha")]
        public DateTime Fecha { get; set; }

        [JsonPropertyName("ValoresPrevios")]
        public Dictionary<string, object?>? ValoresPrevios { get; set; }

        [JsonPropertyName("ValoresNuevos")]
        public Dictionary<string, object?>? ValoresNuevos { get; set; }

        [JsonPropertyName("PropsValoresPrevios")]

        public string[]? PropsValoresPrevios { get; set; }

        [JsonPropertyName("PropsValoresNuevos")]
        public string[]? PropsValoresNuevos { get; set; }
    }
}
