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
        internal static List<SuministrosMovimientosStock>? MapeoSuministrosDB(List<DTOSuministrosMovimientosStock>? Suministros,string? Origen, string? Destino)
        {
            Stocks Stocks = new Stocks();
            List<StockInsumos> StockSuministros = new List<StockInsumos>();
            List<SuministrosMovimientosStock> SuministrosDbContext;

            foreach (DTOSuministrosMovimientosStock suministro in Suministros)
            {
                StockSuministros.Add(Stocks.BuscarInsumo(suministro.IdSuministro));

            }

            //Si encontré, en stock, todos los suministros
            if (StockSuministros.Count > 0 && Suministros.Count == StockSuministros.Count)
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
                        Cantidad = Convert.ToDecimal(x.SuministrosMovimiento.Cantidad),

                        ValorAnteriorOrigen = Convert.ToDecimal(x.StockSuministros
                            .GetType()
                            .GetProperties()
                            .FirstOrDefault(p => p.Name.ToUpper() == Origen.ToUpper())
                            .GetValue(x.StockSuministros) ?? 0),

                        ValorAnteriorDestino = Convert.ToDecimal(x.StockSuministros
                            .GetType()
                            .GetProperties()
                            .FirstOrDefault(p => p.Name.ToUpper()==Destino.ToUpper())
                            .GetValue(x.StockSuministros) ?? 0),

                        ValorNuevoOrigen = Convert.ToDecimal(x.StockSuministros
                            .GetType()
                            .GetProperties()
                            .FirstOrDefault(p => p.Name.ToUpper() == Origen.ToUpper())
                            .GetValue(x.StockSuministros) ?? 0) -
                            Convert.ToDecimal(x.SuministrosMovimiento.Cantidad),

                        ValorNuevoDestino = Convert.ToDecimal(x.StockSuministros
                            .GetType()
                            .GetProperties()
                            .FirstOrDefault(p => p.Name.ToUpper() == Destino.ToUpper())
                            .GetValue(x.StockSuministros) ?? 0) -
                            Convert.ToDecimal(x.SuministrosMovimiento.Cantidad)

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
