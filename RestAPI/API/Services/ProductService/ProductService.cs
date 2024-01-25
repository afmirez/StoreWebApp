using API.Data;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreDB _database;
        public ProductService(StoreDB database)
        {
            this._database = database;
        }
        public IQueryable<Product> ListProducts()
        {
            return this._database
                    .Product
                    .Include(p => p.Category)
                    .Include(p => p.ProductState);
        }
        public async Task<Product?> FindProduct(int id)
        {
            return await this._database
                    .Product
                    .Include(p => p.Category)
                    .Include(p => p.ProductState)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
        }
        public async Task InsertProduct(Product entity)
        {
            this._database.Product.Add(entity);
            await this._database.SaveChangesAsync();
            await this._database.Entry(entity).Reference(p => p.Category).LoadAsync();
            await this._database.Entry(entity).Reference(p => p.ProductState).LoadAsync();
        }
        public async Task UpdateProduct(Product entity)
        {
            this._database.Product.Update(entity);
            await this._database.SaveChangesAsync();
            await this._database.Entry(entity).Reference(p => p.Category).LoadAsync();
            await this._database.Entry(entity).Reference(p => p.ProductState).LoadAsync();
        }
        public async Task DeleteProduct(Product entity)
        {
            this._database.Product.Remove(entity);
            await this._database.SaveChangesAsync();
        }
    }
}