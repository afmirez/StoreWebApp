namespace API.DataTransferObjects
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryStateId { get; set; }
        public GetCategoryDTO CategoryState { get; set; } = null;
    }
}
