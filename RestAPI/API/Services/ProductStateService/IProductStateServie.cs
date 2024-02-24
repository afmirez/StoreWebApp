using API.Data.Models;

namespace API.Services
{
    public interface IProductStateServie
    {
        IQueryable<ProductState> ListProductState();
    }
}
