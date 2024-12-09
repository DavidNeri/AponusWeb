namespace Aponus_Web_API.Modelos
{
    public class PagosCuotasVentas
    {
        public int IdPago { get; set; }
        public int IdCuota { get; set; }

        public virtual PagosVentas Pago { get; set; } = new();
        public virtual CuotasVentas Cuota { get; set; } = new();

    }
}
