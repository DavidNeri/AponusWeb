using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class Productos_Componentes
    {
        
        public string IdProducto { get; set; }
        public string IdComponente {get; set;}
        public decimal? Cantidad { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Longitud { get; set; }

        [ForeignKey("ID_ESTADO")]
        public int IdEstado { get; set; }

        public EstadosProductosComponentes IdEstadoNavigation { get; set; }

    }
}
