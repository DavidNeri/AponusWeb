using System;
using System.Collections.Generic;

namespace Aponus_Web_API.Models;

public partial class ProductCategory
{
    public string CategoryId { get; set; } = null!;

    public string? CategoryDescription { get; set; }

   // public virtual ICollection<Product> Products { get; } = new List<Product>();
}
