using Aponus_Web_API.Acceso_a_Datos.Stocks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class EstadosSuministrosMovimientosStock
    {
        [Key]
        [Column(("ID_ESTADO"))]
        public byte IdEstado { get; set; } = 1;

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        public virtual ICollection<SuministrosMovimientosStock>? SuministrosMovimientoStock{ get; set; }

    }
}
