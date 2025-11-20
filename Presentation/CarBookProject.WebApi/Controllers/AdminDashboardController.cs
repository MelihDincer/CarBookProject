using CarBookProject.Application.Features.Mediator.Queries.AdminDashboardQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminDashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get4Statistics")]
        public async Task<IActionResult> Get4Statistics()
        {
            return Ok(await _mediator.Send(new Get4StatisticsQuery()));
        }
    }
}
