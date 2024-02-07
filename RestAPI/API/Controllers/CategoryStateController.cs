using API.Data.Models;
using API.DataTransferObjects;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/categorystate")]
    [ApiController]
    public class CategoryStateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryStateService _categoryStateService;

        public CategoryStateController(IMapper mapper, ICategoryStateService categoryStateService)
        {
            this._mapper = mapper;
            this._categoryStateService = categoryStateService;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListCategoryState()
        {
            List<CategoryState> list = await this._categoryStateService.ListCategoryState().ToListAsync();
            APIResponse response = new()
            {
                Data = list.Select(c => this._mapper.Map<CategoryState, GetCategoryStateDTO>(c))
            };

            return response;
        }
    }
}

