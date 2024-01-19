using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class SuministrosMovimientosStock
    {
        [Key("ID_MOVIMIENTO")]
        public int IdMovimiento { get; set; }

        [Key("ID_SUMINISTRO")]
        public string IdSuministro { get; set; }        

        [Column("CAMPO_STOCK_ORIGEN")]
        public string? CampoStockOrigen { get; set; }

        [Column("CAMPO_STOCK_DESTINO")]
        public string? CampoStockDestino{ get; set; }

        [Column("VALOR_ANTERIOR_ORIGEN")]
        public decimal? ValorAnteriorOrigen { get; set; }

        [Column("VALOR_ANTERIOR_DESTINO")]
        public decimal? ValorAnteriorDestino{ get; set; }

        [Column("VALOR_NUEVO_ORIGEN")]
        public decimal? ValorNuevoOrigen{ get; set; }

        [Column("VALOR_NUEVO_DESTINO")]
        public decimal? ValorNuevoDestino{ get; set; }

        [Column("CANTIDAD")]
        public decimal Cantidad{ get; set; }


    }
}
