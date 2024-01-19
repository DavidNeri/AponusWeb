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

       [ForeignKey("IdMovimiento")]
        public Stock_Movimientos StockMovimiento { get; set; }



    }
}
