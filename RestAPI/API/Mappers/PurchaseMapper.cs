using API.Data.Models;
using API.DataTransferObjects;
using AutoMapper;

namespace API.Mappers
{
    public class PurchaseMapper : Profile
    {
        public PurchaseMapper() 
        {
            CreateMap<Purchase, GetPurchaseDTO>();
            CreateMap<InsertPurchaseDTO, Purchase>();
        }
    }
}