using Aponus_Web_API.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Negocio
{
    public class BS_Dashboard
    {
        private readonly BS_Ventas BsVentas;
        private readonly BS_Stocks BsStocks;
        private readonly BS_Productos BsProductos;

        public BS_Dashboard(BS_Ventas _BsVentas, BS_Stocks _BsStocks, BS_Productos _BSProductos)
        {
            BsVentas = _BsVentas;
            BsStocks = _BsStocks;
            BsProductos = _BSProductos;
        }

        internal async Task<IActionResult> ProcesarDatosTablero()
        {
            List<Ventas> VentasPendientes = await BsVentas.ObtenerVentasPendientesEntrega();
            var InsumosFaltantes =  await BsStocks.ObentenerInsumosFaltantes();
            var ProductosFaltantes = BsProductos.ObtenerProductosFaltantes();

            return new JsonResult(new
            {
                Ventas = VentasPendientes,
                Insumos = InsumosFaltantes,
                Prodctos = ProductosFaltantes,
            });

        }
    }
}
