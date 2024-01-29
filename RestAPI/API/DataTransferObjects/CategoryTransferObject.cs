namespace API.DataTransferObjects
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryStateId { get; set; }
        public GetCategoryStateDTO CategoryState { get; set; } = null!;
    }
}