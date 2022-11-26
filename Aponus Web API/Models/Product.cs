using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Aponus_Web_API.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;
    public string CategoryId { get; set; } = null!;

    public string ProductDescriptionName { get; set; } = null!;

    public string? ProductDescriptionDn { get; set; }

    public int? ProductDescriptionOutsideDiameter { get; set; }

    public int? ProductDescriptionInsideDiameter { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;
}
