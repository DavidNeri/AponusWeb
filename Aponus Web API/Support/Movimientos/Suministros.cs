using Aponus_Web_API.Acceso_a_Datos.Stocks;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support.Movimientos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Aponus_Web_API.Support.Movimientos
{
    public class Suministros
    {
        private readonly Stocks _stocks;

        public Suministros(Stocks stocks)
        {
            _stocks = stocks;
        }

        internal  List<SuministrosMovimientosStock>? MapeoSuministrosDB(List<DTOSuministrosMovimientosStock>? Suministros,string? Origen, string? Destino)
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
