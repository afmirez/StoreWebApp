using API.Data.Models;
using API.DataTransferObjects;
using API.Services;
using API.Validators;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace API.Controllers
{
    [Route("api/purchases")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseService _purchaseService;
        private readonly IPurchaseValidator _purchaseValidator;

        public PurchaseController(IMapper mapper, IProductService productService, IPurchaseService purchaseService, IPurchaseValidator purchaseValidator)
        {
            this._mapper = mapper;
            this._purchaseService = purchaseService;
            _purchaseValidator = purchaseValidator;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListPurchases()
        {
            List<Purchase > list = await this._purchaseService.ListPurchases()
                                    .OrderBy(p => p.Id)
                                    .ToListAsync();
            APIResponse response = new APIResponse()
            {
                Data = list.Select(p => this._mapper.Map<Purchase, GetPurchaseDTO>(p))
            };
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> InsertPurchaseInsertPurchaseProduct(PurchaseRequest request)
        {
            APIResponse response = new();
            response.Success = this._purchaseValidator.ValidateInsert(request, response.Messages);
            if (response.Success)
            {
                Purchase? purchase = this._mapper.Map<InsertPurchaseDTO, Purchase>(request.PurchaseData);
                List<PurchaseProduct> purchaseProductList = this._mapper.Map<List<InsertPurchaseProductDTO>, List<PurchaseProduct>>(request.PurchaseProductData);
                await this._purchaseService.InsertPurchaseProducts(purchase, purchaseProductList);
                response.Data = "Estamos trabajando en esto...";
                response.Messages.Add("La compra ha sido insertada");
            }
            return response;
        }
    }
}