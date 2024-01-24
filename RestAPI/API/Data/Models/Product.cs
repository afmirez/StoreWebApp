using System;
using System.Collections.Generic;

namespace API.Data.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int ProductStock { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public int ProductStateId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ProductState ProductState { get; set; } = null!;

    public virtual ICollection<PurchaseProduct> PurchaseProduct { get; set; } = new List<PurchaseProduct>();
}
