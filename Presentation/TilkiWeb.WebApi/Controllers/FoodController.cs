using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TilkiWeb.Application.Features.Commands.Food.RemoveFood;
using TilkiWeb.Application.Features.Commands.Food.UpdateFood;
using TilkiWeb.Application.Features.Commands.Foods.CreateFood;
using TilkiWeb.Application.Features.Queries.Food.GetAllFood;
using TilkiWeb.Application.Features.Queries.Food.GetByIdFood;
using TilkiWeb.Application.Features.Queries.Foods.FindFood;

namespace TilkiWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        readonly IMediator _mediator;

        public FoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllFoodQueryRequest getAllFoodQueryRequest)
        {
            GetAllFoodQueryResponse response = await _mediator.Send(getAllFoodQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetFindQueryRequest getByIdFoodQueryRequest)
        {
            GetByIdFoodQueryResponse response = await _mediator.Send(getByIdFoodQueryRequest);
            return Ok(response);
        }
        //   [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(CreateFoodCommandRequest createFoodCommandRequest)
        {
            
            CreateFoodCommandResponse response = await _mediator.Send(createFoodCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
        //   [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateFoodCommandRequest updateFoodCommandRequest)
        {
            UpdateFoodCommandResponse response = await _mediator.Send(updateFoodCommandRequest);
            return Ok();
        }
        //  [Authorize(AuthenticationSchemes = "Admin")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveFoodCommandRequest removeFoodCommandRequest)
        {
            RemoveFoodCommandResponse response = await _mediator.Send(removeFoodCommandRequest);
            return Ok();
        }
        [HttpGet("Find")]
        public async Task<IActionResult> Search([FromQuery] GetFindFoodQueryRequest getFindQueryRequest)
        {
            GetFindQueryResponse response = await _mediator.Send(getFindQueryRequest);
            return Ok(response);
        }
        //// [Authorize(AuthenticationSchemes = "Admin")]
        //[HttpPost("[action]")]
        //public async Task<IActionResult> Upload([FromQuery] UploadFoodImageCommandRequest uploadFoodImageCommandRequest)
        //{
        //    uploadFoodImageCommandRequest.Files = Request.Form.Files;
        //    UploadFoodImageCommandResponse response = await _mediator.Send(uploadFoodImageCommandRequest);
        //    return Ok();
        //}

        //[HttpGet("[action]/{id}")]
        //public async Task<IActionResult> GetFoodmages([FromRoute] GetFoodImagesQueryRequest getFoodImagesQueryRequest)
        //{
        //    List<GetFoodImagesQueryResponse> response = await _mediator.Send(getFoodImagesQueryRequest);
        //    return Ok(response);
        //}
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[HttpDelete("[action]/{id}")]
        //public async Task<IActionResult> DeleteFoodImage([FromRoute] RemoveFoodImageCommandRequest removeFoodImageCommandRequest, [FromQuery] string imageId)
        //{
        //    removeFoodImageCommandRequest.ImageId = imageId;
        //    RemoveFoodImageCommandResponse response = await _mediator.Send(removeFoodImageCommandRequest);
        //    return Ok();
        //}
        //[HttpGet("[action]")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseImageCommandRequest changeShowcaseImageCommandRequest)
        //{
        //    ChangeShowcaseImageCommandResponse response = await _mediator.Send(changeShowcaseImageCommandRequest);
        //    return Ok(response);
        //}


    }
}
