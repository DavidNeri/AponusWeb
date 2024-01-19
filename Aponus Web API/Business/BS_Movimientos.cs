using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Data_Transfer_Objects;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Business
{
    public class BS_Movimientos
    {
        internal IActionResult Listar()
        {
            return new MovimientosStock().Listar();
        }
    }
}
