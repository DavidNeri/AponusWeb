using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class ComponentesDescripcion
{
    public int IdDescripcion { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<CuantitativosDetalle> CuantitativosDetalles { get; set; } = new List<CuantitativosDetalle>();

    public virtual ICollection<MensurablesDetalle> MensurablesDetalles { get; set; } = new List<MensurablesDetalle>();

    public virtual ICollection<PesablesDetalle> PesablesDetalles { get; set; } = new List<PesablesDetalle>();
}
