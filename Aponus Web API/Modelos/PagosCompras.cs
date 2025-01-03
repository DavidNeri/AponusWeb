﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class PagosCompras
    {
        [Key, Column("ID_PAGO", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPago { get; set; }

        [ForeignKey("ID_COMPRA")]
        public int IdCompra { get; set; }

        [ForeignKey("ID_CUOTA")]
        public int? IdCuota { get; set; }

        [ForeignKey("ID_MEDIO_PAGO")]
        public int IdMedioPago { get; set; }

        [Column("MONTO")]
        public decimal Monto { get; set; }

        [Column("FECHA")]
        public DateTime? Fecha { get; set; }

        [ForeignKey("ID_ENTIDAD_PAGO")]
        public int IdEntidadPago { get; set; }
        public virtual MediosPago MedioPago { get; set; } = new();
        public virtual Compras Compra { get; set; } = new();
        public virtual EntidadesPago entidadPago { get; set; } = new();
        public virtual CuotasCompras? Cuota { get; set; }





    }
}
