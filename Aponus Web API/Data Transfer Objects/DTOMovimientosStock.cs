namespace Aponus_Web_API.Data_Transfer_Objects
{
    public class DTOMovimientosStock
    {
        public int IdMovimiento { get; set; }
        public DTOProveedores? ProveedorOrigen { get; set; } 
        public DTOProveedores? ProveedorDestino { get; set; }    
        public DateTime? FechaHora { get; set; }
        public string? Usuario { get; set; }
        public List<DTOSuministrosMovimientosStock> Suministros { get; set; }
        public List<DTOInfoArchivosMovimientosStock>? Archivos { get; set; } = new List<DTOInfoArchivosMovimientosStock>();

    }
}
