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

    public int? ToleranciaMinima { get; set; }

    public int? ToleranciaMaxima { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    
    public virtual ProductosDescripcion IdDescripcionNavigation { get; set; }  = null!;

    public virtual ProductosTipo IdTipoNavigation { get; set; } = null!;
}
