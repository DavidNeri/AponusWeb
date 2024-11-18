using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Aponus_Web_API.Modelos
{
    public class ComponentesDetalle
    {
        [Key]
        public string IdInsumo { get; set; } = string.Empty;
        public int IdDescripcion { get; set; }
        public decimal? Diametro { get; set; }
        public int? DiametroNominal { get; set; }
        public decimal? Espesor { get; set; }
        public decimal? Longitud { get; set; }
        public decimal? Altura { get; set; }
        public int? Perfil { get; set; }
        public string? Tolerancia { get; set; }
        public decimal? Peso { get; set; }
        public string? IdFraccionamiento { get; set; }
        public string? IdAlmacenamiento { get; set; }

        [ForeignKey("ID_ESTADO")]
        public int IdEstado { get; set; }

        public virtual EstadosComponentesDetalles IdEstadoNavigation { get; set; } = new EstadosComponentesDetalles();

        public virtual ICollection<ComprasDetalles> ComprasNavigation { get; set; } = new HashSet<ComprasDetalles>();

    }
}
