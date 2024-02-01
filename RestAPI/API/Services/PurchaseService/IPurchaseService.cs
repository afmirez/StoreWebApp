using API.Data.Models;
namespace API.Services
{
    public interface IPurchaseService
    {
        IQueryable<Purchase> ListPurchases();
        Task InsertPurchaseProducts(Purchase PurchaseEntity, List<PurchaseProduct> PurchaseProductEntities);
    }
}