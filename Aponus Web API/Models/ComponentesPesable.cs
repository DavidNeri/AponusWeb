using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class ComponentesPesable
{
    public string IdProducto { get; set; } = null!;

    public string IdComponente { get; set; } = null!;

    public decimal? Peso { get; set; }
    public int? Cantidad { get; set; }

    public virtual StockPesable IdComponente1 { get; set; } = null!;

    public virtual PesablesDetalle IdComponenteNavigation { get; set; } = null!;
}
