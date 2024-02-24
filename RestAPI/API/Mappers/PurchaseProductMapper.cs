using API.Data.Models;
using API.DataTransferObjects;
using AutoMapper;
namespace API.Mappers
{
    public class PurchaseProductMapper : Profile
    {
        public PurchaseProductMapper()
        {
            CreateMap<InsertPurchaseProductDTO, PurchaseProduct>();
        }
    }
}