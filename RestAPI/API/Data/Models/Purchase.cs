using System;
using System.Collections.Generic;

namespace API.Data.Models;

public partial class Purchase
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public decimal Total { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerDocumentId { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public virtual ICollection<PurchaseProduct> PurchaseProduct { get; set; } = new List<PurchaseProduct>();
}
