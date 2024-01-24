using API.Data.Models;
namespace API.Services
{
    public interface ICategoryState
    {
        IQueryable<CategoryState> ListCategoryStates();
    }
}
