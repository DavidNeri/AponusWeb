using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class Stock_Movimientos
    {
        [Key("ID_MOVIMIENTO")]
        [ForeignKey("ID_MOVIMIENTO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMovimiento { get; set; }        
        public string IdUsuario { get; set; }
        public DateTime FechaHora { get; set; }

        [ForeignKey("ID_PROVEEDOR_ORIGEN")]        
        public int IdProveedorOrigen { get; set; }        

        [ForeignKey("ID_PROVEEDOR_DESTINO")]
        public int IdProveedorDestino { get; set; }

        public Proveedores? ProveedorOrigen { get; set; }
        public Proveedores? ProveedorDestino { get; set; }
        public ICollection<SuministrosMovimientosStock> ? Suministros { get; set; }






    }
}
