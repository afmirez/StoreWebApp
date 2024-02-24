namespace API.DataTransferObjects
{
    public class GetPurchaseDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerDocumentId { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string CustomerAddress { get; set; } = null!;
    }
    public class PurchaseRequest
    {
        public InsertPurchaseDTO? PurchaseData { get; set; }
        public List<InsertPurchaseProductDTO>? PurchaseProductData { get; set; }
    }
    public class InsertPurchaseDTO
    {
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerDocumentId { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }
    }
    public class InsertPurchaseProductDTO
    {
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? PurchaseId { get; set; }
        public int? ProductId { get; set; }
    }
    public class FilterPurchaseDTO
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? TotalFrom { get; set; }
        public decimal? TotalTo { get; set; }
    }
}