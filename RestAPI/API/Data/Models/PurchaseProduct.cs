using System;
using System.Collections.Generic;

namespace API.Data.Models;

public partial class PurchaseProduct
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public int PurchaseId { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Purchase Purchase { get; set; } = null!;
}
