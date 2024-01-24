using API.Data;
using API.Data.Models;
namespace API.Services
{
    public class CategoryStateService : ICategoryState
    {
        private readonly StoreDB _database;
        public CategoryStateService(StoreDB database)
        {
            this._database = database;
        }
        public IQueryable<CategoryState> ListCategoryStates()
        {
            return this._database
                    .CategoryState;
        }
    }
}
