namespace Aponus_Web_API.Modelos
{
    public class StockInsumos
    {
        public string IdInsumo { get; set; } = string.Empty;
        public decimal? Recibido { get; set; }
        public decimal? Granallado{ get; set; }
        public decimal? Pintura{ get; set; }
        public decimal? Proceso{ get; set; }
        public decimal? Moldeado{ get; set; }
        public decimal? Pendiente { get; set;}


    }
}
