using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class ProductosDescripcion
{
    public int IdDescripcion { get; set; }

    public string? DescripcionProducto { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List <Producto>();

    public List<Productos_Tipos_Descripcion> Producto_Tipo_Descripcione { get; set; }
}
    