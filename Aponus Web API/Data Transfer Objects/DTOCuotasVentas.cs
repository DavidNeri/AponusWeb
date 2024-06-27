using Aponus_Web_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOCuotasVentas
    {
        public int IdCuota { get; set; }
        public int IdVenta { get; set; }
        public string NumeroCuota { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdEstadoCuota { get; set; }
        public DateTime FechaPago { get; set; }
        public virtual DTOEstadosCuotasVentas EstadoCuota { get; set; } = new DTOEstadosCuotasVentas();
    }
}