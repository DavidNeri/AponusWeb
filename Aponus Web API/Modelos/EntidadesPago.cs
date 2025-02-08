namespace Aponus_Web_API.Modelos
{
    public class EntidadesPago
    {
        public int IdEntidad { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Emisor { get; set; } = string.Empty;

        public ICollection<PagosVentas> pagosVentas { get; set; } = new HashSet<PagosVentas>();
        public ICollection<PagosCompras> pagosCompras { get; set; } = new HashSet<PagosCompras>();


    }
}
