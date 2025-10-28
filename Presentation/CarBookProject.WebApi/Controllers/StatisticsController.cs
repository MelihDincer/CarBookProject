using CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var values = await _mediator.Send(new GetCarCountQuery());
            return Ok(values);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var values = await _mediator.Send(new GetLocationCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var values = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _mediator.Send(new GetBlogCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _mediator.Send(new GetBrandCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceDaily")]
        public async Task<IActionResult> GetAvgRentPriceDaily()
        {
            var values = await _mediator.Send(new GetAvgRentPriceDailyQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceWeekly")]
        public async Task<IActionResult> GetAvgRentPriceWeekly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceWeeklyQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceMonthly")]
        public async Task<IActionResult> GetAvgRentPriceMonthly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceMonthlyQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByTransmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTransmissionIsAuto()
        {
            var values = await _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandNameWithMostCars")]
        public async Task<IActionResult> GetBrandNameWithMostCars()
        {
            var values = await _mediator.Send(new GetBrandNameWithMostCarsQuery());
            return Ok(values);
        }

        [HttpGet(" GetBlogTitleWithMostComments")]
        public async Task<IActionResult> GetBlogTitleWithMostComments()
        {
            var values = await _mediator.Send(new GetBlogTitleWithMostCommentQuery());
            return Ok(values);
        }

        [HttpGet("GetCarsWithLessThan1000Km")]
        public async Task<IActionResult> GetCarsWithLessThan1000Km()
        {
            var values = await _mediator.Send(new GetCarsWithLessThan1000KmQuery());
            return Ok(values);
        }

        [HttpGet("GetGasolineOrDieselCars")]
        public async Task<IActionResult> GetGasolineOrDieselCars()
        {
            var values = await _mediator.Send(new GetGasolineOrDieselCarsQuery());
            return Ok(values);
        }

        [HttpGet("GetElectricCars")]
        public async Task<IActionResult> GetElectricCars()
        {
            var values = await _mediator.Send(new GetElectricCarsQuery());
            return Ok(values);
        }

        [HttpGet("GetMostExpensiveCarBrand")]
        public async Task<IActionResult> GetMostExpensiveCarBrand()
        {
            var values = await _mediator.Send(new GetMostExpensiveCarBrandQuery());
            return Ok(values);
        }

        [HttpGet("GetCheapestCarBrand")]
        public async Task<IActionResult> GetCheapestCarBrand()
        {
            var values = await _mediator.Send(new GetCheapestCarBrandQuery());
            return Ok(values);
        }
    }
}
