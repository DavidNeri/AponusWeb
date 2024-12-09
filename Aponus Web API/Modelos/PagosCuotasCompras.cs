namespace Aponus_Web_API.Modelos
{
    public class PagosCuotasCompras
    {
        public int IdPago { get; set; }
        public int IdCuota { get; set; }

        public virtual PagosCompras Pago { get; set; } = new();
        public virtual CuotasCompras Cuota { get; set; } = new();


    }
}
