using API.Data.Models;
using API.DataTransferObjects;
using API.Services;
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
        public PurchaseController(IMapper mapper, IPurchaseService purchaseService)
        {
            this._mapper = mapper;
            this._purchaseService = purchaseService;
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


    }
}