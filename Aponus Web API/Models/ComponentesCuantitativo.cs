using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class ComponentesCuantitativo
{
    public string IdProducto { get; set; } = null!;

    public string IdComponente { get; set; } = null!;

    public int Cantidad { get; set; }

    public virtual StockCuantitativo IdComponente1 { get; set; } = null!;

    public virtual CuantitativosDetalle IdComponenteNavigation { get; set; } = null!;


}
