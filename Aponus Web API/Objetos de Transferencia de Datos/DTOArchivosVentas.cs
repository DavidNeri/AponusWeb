namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOArchivosVentas
    {
        public int IdVenta { get; set; }
        public int IdArchivo { get; set; }
        public string HashArchivo { get; set; } = string.Empty;
        public string PathArchivo { get; set; } = string.Empty;
        public string? MimeType { get; set; }
        public int IdEstado { get; set; } = 1;

    }
}
