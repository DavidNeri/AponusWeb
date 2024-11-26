namespace Aponus_Web_API.Modelos
{
    public class Auditorias
    {
        public int IdAuditoria { get; set; }
        public string Tabla { get; set; } = "";
        public string IdRegistro { get; set; } = "";
        public string Accion { get; set; } = "";
        public string Usuario { get; set; } = "";
        public DateTime Fecha { get; set; }
        public string ValoresPrevios { get; set; } = "";
        public string ValoresNuevos { get; set; } = "";
    }
}