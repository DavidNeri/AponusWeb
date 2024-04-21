using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class EstadosArchivosMovimientosStock
    {
        [Key]
        [Column(("ID_ESTADO"))]
        public byte IdEstado { get; set; } = 1;

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        public ICollection<ArchivosMovimientosStock> ArchivosMovimientoStock { get; set; }

    }
}
