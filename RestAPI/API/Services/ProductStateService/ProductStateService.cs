using API.Data;
using API.Data.Models;

namespace API.Services
{
    public class ProductStateService : IProductStateServie
    {
        private readonly StoreDB _database;

        public ProductStateService(StoreDB database)
        {
            this._database = database;
        }
        public IQueryable<ProductState> ListProductState()
        {
            return this._database
                .ProductState;
        }
    }
}
