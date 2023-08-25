using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aponus_Web_API.Models;

public partial class ProductosDescripcion
{
    [Column("ID_DESCRIPCION")]
    public int IdDescripcion { get; set; }

    [Column("DESCRIPCION")]
    public string? DescripcionProducto { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List <Producto>();

    //public virtual ICollection<Productos_Tipos_Descripcion> Producto_Tipo_Descripcione { get; set; }
}
    