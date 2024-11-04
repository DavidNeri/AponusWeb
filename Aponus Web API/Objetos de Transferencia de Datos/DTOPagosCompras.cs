namespace Aponus_Web_API.Objetos_de_Transferencia_de_Datos
{
    public class DTOPagosCompras
    {
        public int IdPago { get; set; }
        public int IdCompra { get; set; }
        public int IdMedioPago { get; set; }
        public decimal Monto { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual DTOMediosPago MedioPago { get; set; } = new();
        public virtual DTOCompras Compra { get; set; } = new();

    }
}
