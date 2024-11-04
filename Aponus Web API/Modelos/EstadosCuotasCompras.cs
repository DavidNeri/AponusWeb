using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class EstadosCuotasCompras
    {
        [Key]
        [Column("ID_ESTADO_CUOTA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstadoCuota { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        public virtual ICollection<CuotasCompras> IdEstadoCuotaNavigation { get; set; } = new HashSet<CuotasCompras>();

    }
}