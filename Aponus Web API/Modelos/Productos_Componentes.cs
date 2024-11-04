using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class Productos_Componentes
    {
        public string IdProducto { get; set; } = string.Empty;
        public string IdComponente { get; set; } = string.Empty;
        public decimal? Cantidad { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Longitud { get; set; }

        [ForeignKey("ID_ESTADO")]
        public int IdEstado { get; set; }

        public virtual EstadosProductosComponentes IdEstadoNavigation { get; set; } = new EstadosProductosComponentes();

    }
}
