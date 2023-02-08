using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class PesablesDetalle
{
    public string IdComponente { get; set; } = null!;

    public int? IdDescripcion { get; set; }

    public int? Diametro { get; set; }

    public decimal? Altura { get; set; }

    public virtual ICollection<ComponentesPesable> ComponentesPesables { get; } = new List<ComponentesPesable>();

    public virtual ComponentesDescripcion? IdDescripcionNavigation { get; set; }

    public virtual StockPesable? StockPesable { get; set; }
}
