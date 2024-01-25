using API.Data.Models;

namespace API.DataTransferObjects
{
    public class GetProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int ProductStock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ProductStateId { get; set; }
        public GetCategoryDTO Category { get; set; } = null;
        public GetProductStateDTO ProducState { get; set; } = null;
    }

    public class InsertUpdateProductDTO
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public int? ProductStock { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductStateId { get; set; }
    }
}