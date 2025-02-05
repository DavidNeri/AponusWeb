using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class ArchivosVentas
    {
        [ForeignKey("ID_VENTA")]
        public int IdVenta { get; set; }
        public int IdArchivo{ get; set; }
        public string HashArchivo { get; set; } = string.Empty;
        public string PathArchivo { get; set; } = string.Empty;
        public string? MimeType { get; set; }
        public int IdEstado { get; set; } = 1;

        public virtual Ventas VentasNavigation{ get; set; } = new Ventas();
    }
}
