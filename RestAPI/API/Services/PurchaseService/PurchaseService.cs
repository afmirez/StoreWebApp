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
    }
}