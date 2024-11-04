using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class EstadosSuministrosMovimientosStock
    {
        [Key]
        [Column(("ID_ESTADO"))]
        public int IdEstado { get; set; } = 1;

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = string.Empty;

        public virtual ICollection<SuministrosMovimientosStock>? SuministrosMovimientoStock { get; set; }

    }
}
