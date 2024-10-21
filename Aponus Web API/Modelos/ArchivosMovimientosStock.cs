using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class ArchivosMovimientosStock
    {
        public int IdMovimiento { get; set; }
        public string HashArchivo { get; set; } = string.Empty;
        public string PathArchivo { get; set; } = string.Empty;
        public string? MimeType{ get; set; }
        public int IdEstado { get; set; } = 1;

        [ForeignKey("IdMovimiento")]
        public virtual Stock_Movimientos StockMovimiento { get; set; } = new Stock_Movimientos();
        public virtual EstadosArchivosMovimientosStock? ArchivosMovimientosStockNavigation { get; set; }


    }
}
