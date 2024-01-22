using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Business
{
    public class BS_Movimientos
    {
        internal IActionResult Listar(FiltrosMovimientos? Filtros)
        {
            if (Filtros!=null)
            {
                return new MovimientosStock().Listar(Filtros);

            }
            else
            {
                
                return new MovimientosStock().Listar();
            }
           
        }
    }
}
