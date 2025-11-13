using CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarPricingsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarPricingsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("GetCarPricingWithCarList")]
		public async Task<IActionResult> GetCarPricingWithCarList()
		{
			return Ok(await _mediator.Send(new GetCarPricingWithCarQuery()));
		}

        [HttpGet("GetCarPricingWithTimePeriod")]
        public async Task<IActionResult> GetCarPricingWithTimePeriod()
        {
            return Ok(await _mediator.Send(new GetCarPricingWithTimePeriodQuery()));
        }
    }
}
