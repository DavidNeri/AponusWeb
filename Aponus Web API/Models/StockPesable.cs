using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class StockPesable
{
    public string IdComponente { get; set; } = null!;

    public decimal? CantidadRecibido { get; set; }

    public decimal? CantidadPintura { get; set; }

    public decimal? CantidadProceso { get; set; }

    public virtual ICollection<ComponentesPesable> ComponentesPesables { get; } = new List<ComponentesPesable>();

    public virtual PesablesDetalle IdComponenteNavigation { get; set; } = null!;
}
