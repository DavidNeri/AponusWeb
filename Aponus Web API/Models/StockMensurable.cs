using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class StockMensurable
{
    public string IdComponente { get; set; } = null!;

    public int? CantidadRecibido { get; set; }

    public int? CantidadProceso { get; set; }

    public virtual ICollection<ComponentesMensurable> ComponentesMensurables { get; } = new List<ComponentesMensurable>();

    public virtual MensurablesDetalle? MensurablesDetalle { get; set; }
}
