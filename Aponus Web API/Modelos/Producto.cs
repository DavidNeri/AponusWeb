using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Aponus_Web_API.Modelos;

public partial class Producto
{
    public string IdProducto { get; set; } = null!;

    public int IdDescripcion { get; set; }

    public string IdTipo { get; set; } = null!;

    public int? DiametroNominal { get; set; }

    public string? Tolerancia { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioLista { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? PrecioFinal { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? PorcentajeGanancia { get; set; }

    [ForeignKey("ID_ESTADO")]
    public int IdEstado { get; set; }

    public virtual ProductosDescripcion IdDescripcionNavigation { get; set; }  = null!;
    public virtual ProductosTipo IdTipoNavigation { get; set; } = null!;
    public virtual EstadosProductos IdEstadoNavigation { get; set; } = new EstadosProductos();
    public virtual ICollection<VentasDetalles> Ventas { get; set; } = default!;

}
