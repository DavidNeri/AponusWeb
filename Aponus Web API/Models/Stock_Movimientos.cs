﻿using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models
{
    public class Stock_Movimientos
    {
        [Key("ID_MOVIMIENTO")]
        [ForeignKey("ID_MOVIMIENTO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMovimiento { get; set; }

        [Column("USUARIO_CREADO")]
        public string CreadoUsuario { get; set; }

        [Column("FECHA_HORA_CREADO")]
        public DateTime FechaHoraCreado { get; set; }

        [Column("USUARIO_MODIFICA")]
        public string ModificadoUsuario { get; set; }

        [Column("FECHA_HORA_ULTIMA_MODIFICACION")]
        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [ForeignKey("ID_PROVEEDOR_ORIGEN")]        
        public int IdProveedorOrigen { get; set; }        

        [ForeignKey("ID_PROVEEDOR_DESTINO")]
        public int IdProveedorDestino { get; set; }

        [Column("ORIGEN")]
        public string? Origen { get; set; }

        [Column("DESTINO")]
        public string? Destino { get; set; }

        [Column("TIPO")]
        public string? Tipo { get; set; }
        public int IdEstado { get; set; } = 1;

        public Proveedores? ProveedorOrigen { get; set; }
        public Proveedores? ProveedorDestino { get; set; }
        public EstadosMovimientosStock? estadoMovimiento { get; set; }
        public ICollection<SuministrosMovimientosStock>? Suministros { get; set; }



    }
}