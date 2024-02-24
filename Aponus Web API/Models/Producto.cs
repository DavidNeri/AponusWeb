using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models;

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
    public decimal? PrecioFinal{ get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? PorcentajeGanancia { get; set; }

    [ForeignKey("ID_ESTADO")]
    public int IdEstado { get; set; }

    public virtual ProductosDescripcion IdDescripcionNavigation { get; set; }  = null!;
    public virtual ProductosTipo IdTipoNavigation { get; set; } = null!;
    public EstadosProductos IdEstadoNavigation { get; set; }
    public virtual ICollection<ComponentesCuantitativo>? ComponentesCuantitativos { get; set;} = new List<ComponentesCuantitativo>();


}
