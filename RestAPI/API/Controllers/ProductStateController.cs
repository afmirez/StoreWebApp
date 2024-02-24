using API.Data.Models;
using API.DataTransferObjects;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/productstate")]
    [ApiController]
    public class ProductStateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductStateServie _productStateServie;

        public ProductStateController(IMapper mapper, IProductStateServie productStateServie) 
        {         
            this._mapper = mapper;
            this._productStateServie = productStateServie;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListProductState()
        {
            List<ProductState> list = await this._productStateServie.ListProductState().ToListAsync();

            APIResponse response = new()
            {
                Data = list.Select(p => this._mapper.Map<ProductState, GetProductStateDTO>(p))
            };

            return response;
        }
    }
}
