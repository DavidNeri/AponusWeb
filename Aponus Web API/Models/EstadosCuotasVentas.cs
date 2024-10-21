using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class EstadosCuotasVentas
    {
        [Key]
        [Column("ID_ESTADO_CUOTA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstadoCuota { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        public  virtual ICollection<CuotasVentas> IdEstadoCuotaNavigation { get; set; } = new HashSet<CuotasVentas>();


    }
}
