using API.Data.Models;
namespace API.Services
{
    public interface IProductService
    {
        IQueryable<Product> ListProducts();
        Task<Product?> FindProduct(int id);
        Task InsertProduct(Product entity);
        Task UpdateProduct(Product entity);
        Task DeleteProduct(Product entity);
    }
}