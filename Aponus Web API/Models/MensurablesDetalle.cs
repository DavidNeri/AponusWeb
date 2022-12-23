using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class MensurablesDetalle
{
    public string IdComponente { get; set; } = null!;

    public int? IdDescripcion { get; set; }

    public decimal? Largo { get; set; }

    public decimal? Ancho { get; set; }

    public decimal? Altura { get; set; }

    public decimal? Espesor { get; set; }

    public int? Perfil { get; set; }

    public virtual ICollection<ComponentesMensurable> ComponentesMensurables { get; } = new List<ComponentesMensurable>();

    public virtual StockMensurable IdComponenteNavigation { get; set; } = null!;

    public virtual ComponentesDescripcion? IdDescripcionNavigation { get; set; }
}
