using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class ArchivosMovimientosStock
    {
        public int IdMovimiento { get; set; }
        public string HashArchivo { get; set; }
        public string PathArchivo { get; set; }
        public string? MimeType{ get; set; }
        public byte IdEstado { get; set; } = 1;

        [ForeignKey("IdMovimiento")]
        public Stock_Movimientos StockMovimiento { get; set; }
        public EstadosArchivosMovimientosStock? ArchivosMovimientosStockNavigation { get; set; }


    }
}
