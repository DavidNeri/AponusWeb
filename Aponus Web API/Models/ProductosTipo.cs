using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class ProductosTipo
{
    public string IdTipo { get; set; } = null!;

    public string? DescripcionTipo { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
