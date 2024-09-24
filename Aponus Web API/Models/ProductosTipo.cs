using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aponus_Web_API.Models;

public partial class ProductosTipo
{
    
    [Column("ID_TIPO")]
    public string IdTipo { get; set; } = null!;

    [Column("DESCRIPCION")]
    public string? DescripcionTipo { get; set; }

    [ForeignKey("ID_ESTADO")]
    public int IdEstado { get; set; }
    
    public virtual ICollection<Producto> Productos{ get; set;} = new List<Producto>();
  
    public virtual EstadosTiposProductos IdEstadoNavigation { get; set; }

    //Navigation Propertires
    public virtual ICollection<Productos_Tipos_Descripcion> Producto_Tipo_Descripcione { get; set; } = new HashSet<Productos_Tipos_Descripcion>();

}
