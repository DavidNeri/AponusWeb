using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Modelos
{
    public class Stock_Movimientos
    {
        [Key("ID_MOVIMIENTO")]
        [ForeignKey("ID_MOVIMIENTO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMovimiento { get; set; }

        [Column("USUARIO_CREADO")]
        public string CreadoUsuario { get; set; } = "";

        [Column("FECHA_HORA_CREADO")]
        public DateTime FechaHoraCreado { get; set; }

        [Column("USUARIO_MODIFICA")]
        public string? ModificadoUsuario { get; set; }

        [Column("FECHA_HORA_ULTIMA_MODIFICACION")]
        public DateTime? FechaHoraUltimaModificacion { get; set; }

        [ForeignKey("ID_PROVEEDOR")]
        public int IdProveedor { get; set; }

        [Column("ORIGEN")]
        public string? Origen { get; set; }

        [Column("DESTINO")]
        public string? Destino { get; set; }

        [Column("TIPO")]
        public string? Tipo { get; set; }

        [Column("ID_ESTADO_MOVIMIENTO")]
        public int IdEstadoMovimiento { get; set; } = 1;

        public virtual Entidades? Proveeedor { get; set; }
        public virtual EstadosMovimientosStock? estadoMovimiento { get; set; }
        public virtual ICollection<SuministrosMovimientosStock>? Suministros { get; set; }



    }
}
