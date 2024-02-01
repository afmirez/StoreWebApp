namespace API.DataTransferObjects
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryStateId { get; set; }
        public GetCategoryStateDTO CategoryState { get; set; } = null!;
    }
    public class InsertUpdateCategoryDTO
    {
        public string? Name { get; set; }
        public int? CategoryStateId { get; set; }
    }

    public class FilterCategoryDTO
    {
        public string? Name { get; set; }
        public int? CategoryStateId { get; set; }
    }
}