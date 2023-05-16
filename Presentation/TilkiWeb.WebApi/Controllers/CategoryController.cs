using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TilkiWeb.Application.Features.Commands.Foods.CreateFood;
using TilkiWeb.Application.Features.Queries.Category.GetAllCategory;
using TilkiWeb.Application.Features.Queries.Category.GetFoodByCategory;
using TilkiWeb.Application.Features.Queries.Food.GetAllFood;
using TilkiWeb.Application.Features.Queries.Food.GetByIdFood;

namespace TilkiWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllCategoryQueryResponse response = await _mediator.Send(new GetAllCategoryQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommandRequest createCategoryCommandRequest)
        {

            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdCategoryQueryRequest getByIdFoodQueryRequest)
        {
            GetByIdCategoryQueryResponse response = await _mediator.Send(getByIdFoodQueryRequest);
            return Ok(response);
        }
        [HttpGet("[action]/{CategoryId}")]
        public async Task<IActionResult> GetFoodsByCategory([FromRoute] GetFoodByCategoryRequest getByIdFoodQueryRequest)
        {
            GetFoodByCategoryResponse response = await _mediator.Send(getByIdFoodQueryRequest);
            return Ok(response);
        }

    }
}
