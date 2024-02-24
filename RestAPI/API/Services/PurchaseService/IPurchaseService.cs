using API.Data.Filters;
using API.Data.Models;
namespace API.Services
{
    public interface IPurchaseService
    {
        IQueryable<Purchase> ListPurchases(PurchaseListFilter? filter = null);
        Task InsertPurchaseProducts(Purchase PurchaseEntity, List<PurchaseProduct> PurchaseProductEntities);
    }
}