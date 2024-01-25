using API.Data.Models;
namespace API.Services.CategoryService
{
    public interface ICategoryService
    {
        IQueryable<Category> ListCategories();
    }
}