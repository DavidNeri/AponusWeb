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

        [JsonPropertyName("usuario")]
        public string Usuario { get; set; } = "";

        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }

        [JsonPropertyName("valoresPrevios")]
        public string? ValoresPrevios { get; set; }

        [JsonPropertyName("valoresNuevos")]
        public string? ValoresNuevos { get; set; }

      
    }
}
