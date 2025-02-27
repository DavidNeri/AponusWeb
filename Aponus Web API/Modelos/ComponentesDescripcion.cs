﻿namespace Aponus_Web_API.Modelos;

public partial class ComponentesDescripcion
{

    [MessagePack.Key("ID_DESCRIPCION")]
    public int IdDescripcion { get; set; }

    public string? Descripcion { get; set; }

    public string IdAlmacenamiento { get; set; } = string.Empty;

    public string? IdFraccionamiento { get; set; }
    public  int IdEstado { get; set; }


}
