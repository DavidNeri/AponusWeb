using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class CuantitativosDetalle
{
    public string IdComponente { get; set; } = null!;

    public int? IdDescripcion { get; set; }

    public decimal? Diametro { get; set; }

    public decimal? Altura { get; set; }

    public int? ToleranciaMinima { get; set; }

    public int? ToleranciaMaxima { get; set; }

    public virtual ICollection<ComponentesCuantitativo> ComponentesCuantitativos { get; } = new List<ComponentesCuantitativo>();

    public virtual ComponentesDescripcion? IdDescripcionNavigation { get; set; }

    public virtual StockCuantitativo? StockCuantitativo { get; set; }
}
