using API.Data;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace API.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly StoreDB _database;
        public PurchaseService(StoreDB database)
        {
            this._database = database;
        }
        public IQueryable<Purchase> ListPurchases()
        {
            return this._database
                    .Purchase;
        }

        public async Task InsertPurchaseProducts(Purchase PurchaseEntity, List<PurchaseProduct> PurchaseProductEntities)
        {
            // Insertamos un elemento Purchase a la DB
            this._database.Purchase.Add(PurchaseEntity);
            await this._database.SaveChangesAsync();

            // Obtenemos el ID del elemento Purchase insertado
            int newPurchaseId = PurchaseEntity.Id;

            //// Insertamos en la DB un elemento PurchaseProduct por cada objeto que traiga la lista 
            foreach (var purchaseProductEntity in PurchaseProductEntities)
            {
                // Asignamos el ID del elemento Purchase como valor de PurchaseProduct.PurchaseId
                purchaseProductEntity.PurchaseId = newPurchaseId;
                this._database.PurchaseProduct.Add(purchaseProductEntity);
            }
            await this._database.SaveChangesAsync();
        }
    }
}