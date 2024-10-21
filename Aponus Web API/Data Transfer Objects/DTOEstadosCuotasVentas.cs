using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOEstadosCuotasVentas
    {
        public int IdEstadoCuota { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int IdEstado { get; set; }
    }
}