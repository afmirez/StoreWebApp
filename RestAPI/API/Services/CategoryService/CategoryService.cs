using API.Data;
using API.Data.Models;
namespace API.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly StoreDB _database;
        public CategoryService(StoreDB database)
        {
            this._database = database;
        }
        public IQueryable<Category> ListCategories()
        {
            return this._database
                    .Category;
        }
    }
}