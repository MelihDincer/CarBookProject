using CarBookProject.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetRentACarListByLocation")]
        public async Task<IActionResult> GetRentACarListByLocation([FromQuery]GetRentACarQuery getRentACarQuery)
        {
            getRentACarQuery.Available ??= true;
            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        }
        //public async Task<IActionResult> GetRentACarListByLocation(int locationID, bool? available)
        //{
        //    available ??= true;
        //    GetRentACarQuery getRentACarQuery = new GetRentACarQuery(locationID, available);
        //    var values = await _mediator.Send(getRentACarQuery);
        //    return Ok(values);
        //}
    }
}
