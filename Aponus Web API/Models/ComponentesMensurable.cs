using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class ComponentesMensurable
{
    public string IdProducto { get; set; } = null!;

    public string IdComponente { get; set; } = null!;

    public decimal? Largo { get; set; }

    public decimal? Altura { get; set; }

    public virtual StockMensurable IdComponente1 { get; set; } = null!;

    public virtual MensurablesDetalle IdComponenteNavigation { get; set; } = null!;
}
