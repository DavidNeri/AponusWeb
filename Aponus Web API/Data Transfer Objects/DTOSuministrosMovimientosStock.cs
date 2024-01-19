namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOSuministrosMovimientosStock
    {
        public int IdMovimiento { get; set; }
        public string IdSuministro { get; set; }
        public string? CampoStockOrigen { get; set; }
        public string? CampoStockDestino { get; set; }
        public decimal? ValorAnteriorOrigen { get; set; }
        public decimal? ValorAnteriorDestino { get; set; }
        public decimal? ValorNuevoOrigen { get; set; }
        public decimal? ValorNuevoDestino { get; set; }
        public decimal Cantidad { get; set; }

    }
}
