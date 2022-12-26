namespace Aponus_Web_API.Models
{
    public class InsumosProducto
    {

        public string? Insumo { get; set; } = null;
        public IEnumerable<decimal>?  Medida { get; set; } = null;
        public double? Cantidad_Producto { get; set; } = null;
    }
}
