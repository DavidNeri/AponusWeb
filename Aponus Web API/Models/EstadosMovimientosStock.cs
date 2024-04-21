using Aponus_Web_API.Acceso_a_Datos.Stocks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class EstadosMovimientosStock
    {
        [Key]
        [Column(("ID_ESTADO"))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdEstado { get; set; } = 1;

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        [Column("ID_ESTADO_PROPIO")]
        public byte? IdEstadoPropio { get; set; }

        public ICollection<Stock_Movimientos> movimientosStock{ get; set; }

    }
}
