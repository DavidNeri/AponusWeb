using Aponus_Web_API.Acceso_a_Datos.Stocks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class EstadosMovimientosStock
    {
        [Key]
        [Column("ID_ESTADO_MOVIMIENTO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdEstadoMovimiento { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("ID_ESTADO_PROPIO")]
        public int IdEstado { get; set; }

        public virtual ICollection<Stock_Movimientos> movimientosStock { get; set; } = new List<Stock_Movimientos>();

    }
}
