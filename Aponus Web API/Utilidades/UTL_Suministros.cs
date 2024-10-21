using Aponus_Web_API.Acceso_a_Datos;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Modelos;

namespace Aponus_Web_API.Utilidades
{
    public class UTL_Suministros
    {
        private readonly AD_Stocks _stocks;

        public UTL_Suministros(AD_Stocks stocks)
        {
            _stocks = stocks;
        }

        internal List<SuministrosMovimientosStock>? MapeoSuministrosDB(List<DTOSuministrosMovimientosStock>? Suministros, string? Origen, string? Destino)
        {
            List<StockInsumos> StockSuministros = new List<StockInsumos>();
            List<SuministrosMovimientosStock> SuministrosDbContext;

            foreach (DTOSuministrosMovimientosStock suministro in Suministros ?? Enumerable.Empty<DTOSuministrosMovimientosStock>())
            {
                StockSuministros.Add(_stocks.BuscarInsumo(suministro.IdSuministro) ?? new StockInsumos());
            }

            //Si encontré, en stock, todos los Suministros
            if (StockSuministros.Count > 0 && Suministros != null && Suministros.Count == StockSuministros.Count)
            {
                SuministrosDbContext = new List<SuministrosMovimientosStock>();

                SuministrosDbContext = StockSuministros
                    .Join(Suministros,
                        StockSuministros => StockSuministros.IdInsumo,
                        SuministrosMovimiento => SuministrosMovimiento.IdSuministro,
                        (StockSuministros, SuministrosMovimiento) => new
                        {
                            StockSuministros,
                            SuministrosMovimiento
                        })
                    .Select(x => new SuministrosMovimientosStock()
                    {
                        IdSuministro = x.SuministrosMovimiento.IdSuministro,
                        Cantidad = Convert.ToDecimal(x.SuministrosMovimiento.Cantidad)

                    })
                    .ToList();

                return SuministrosDbContext;
            }
            else
            {
                return null;
            }



        }
    }

}
