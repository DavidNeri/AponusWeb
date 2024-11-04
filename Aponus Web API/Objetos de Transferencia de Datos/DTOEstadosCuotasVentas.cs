namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOEstadosCuotasVentas
    {
        public int IdEstadoCuota { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int IdEstado { get; set; }
    }
}