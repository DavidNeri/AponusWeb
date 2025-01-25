using System.Text.Json.Nodes;

namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOAuditorias
    {
        public int IdAuditoria { get; set; }
        public string Tabla { get; set; } = "";
        public string IdRegistro { get; set; } = "";
        public string Accion { get; set; } = "";
        public string Usuario { get; set; } = "";
        public DateTime Fecha { get; set; }        
        public Dictionary<string, object>? ValoresPrevios { get; set; }
        public Dictionary<string, object>? ValoresNuevos { get; set; }
    }
}
