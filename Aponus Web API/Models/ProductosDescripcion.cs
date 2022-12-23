using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class ProductosDescripcion
{
    public int IdDescripcion { get; set; }

    public string? DescripcionProducto { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List <Producto>();
}
    