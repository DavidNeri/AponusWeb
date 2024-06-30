using Aponus_Web_API.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOVentas
    {
        public int IdVenta { get; set; }

        [Required(ErrorMessage ="El campo 'Cliente' es obligatorio")]
        public int IdCliente { get; set; }

        public DateTime? FechaHora { get; set; }

        [Required(ErrorMessage = "El campo 'Usuario' es obligatorio")]
        public string IdUsuario { get; set; }

        public int? IdEstadoVenta { get; set; }

        public decimal Monto { get; set; } = 0;

        public decimal? SaldoCancelado { get; set; }

        public decimal SaldoPendiente => Monto - (SaldoCancelado ?? 0);

        public ICollection<DTOVentasDetalles> DetallesVenta { get; set; } = new HashSet<DTOVentasDetalles>();
        public ICollection<DTOPagosVentas> Pagos { get; set; } = new HashSet<DTOPagosVentas>();
        public virtual ICollection<DTOCuotasVentas> Cuotas { get; set; } = new HashSet<DTOCuotasVentas>();

    }
}
