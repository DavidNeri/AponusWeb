namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOSuministrosMovimientosStock
    {
        public int IdMovimiento { get; set; }
        public string IdSuministro { get; set; }
        public string? NombreSuministro { get; set; }
        public string? CampoStockOrigen { get; set; }
        public string? CampoStockDestino { get; set; }
        public string? ValorAnteriorOrigen { get; set; }
        public string? ValorAnteriorDestino { get; set; }
        public string? ValorNuevoOrigen { get; set; }
        public string? ValorNuevoDestino { get; set; }
        public string? Cantidad { get; set; }

    }
}
