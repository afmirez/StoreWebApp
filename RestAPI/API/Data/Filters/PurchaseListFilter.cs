namespace API.Data.Filters
{
    public class PurchaseListFilter
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? TotalFrom { get; set; }
        public decimal? TotalTo { get; set; }
    }
}
