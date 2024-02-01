using API.Data.Models;
namespace API.Services
{
    public interface IPurchaseService
    {
        IQueryable<Purchase> ListPurchases();
    }
}