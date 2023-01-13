using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class StockCuantitativo
{
    public string IdComponente { get; set; } = null!;

    public int? CantidadRecibido { get; set; }

    public int? CantidadGranallado { get; set; }

    public int? CantidadPintura { get; set; }

    public int? CantidadProceso { get; set; }
    public int? CantidadMoldeado { get; set; }


    public virtual ICollection<ComponentesCuantitativo> ComponentesCuantitativos { get; } = new List<ComponentesCuantitativo>();

    public virtual CuantitativosDetalle IdComponenteNavigation { get; set; } = null!;
}
