using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class ComponentesDescripcion
{
    public int IdDescripcion { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<CuantitativosDetalle> CuantitativosDetalles { get; } = new List<CuantitativosDetalle>();

    public virtual ICollection<MensurablesDetalle> MensurablesDetalles { get; } = new List<MensurablesDetalle>();

    public virtual ICollection<PesablesDetalle> PesablesDetalles { get; } = new List<PesablesDetalle>();
}
