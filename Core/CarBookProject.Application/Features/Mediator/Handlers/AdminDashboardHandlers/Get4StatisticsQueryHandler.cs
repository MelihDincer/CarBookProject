using CarBookProject.Application.Features.Mediator.Queries.AdminDashboardQueries;
using CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBookProject.Application.Features.Mediator.Results.AdminDashboardResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.AdminDashboardHandlers
{
    public class Get4StatisticsQueryHandler : IRequestHandler<Get4StatisticsQuery, Get4StatisticsQueryResult>
    {
        private readonly IMediator _mediator;

        public Get4StatisticsQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Get4StatisticsQueryResult> Handle(Get4StatisticsQuery request, CancellationToken cancellationToken)
        {
            var carCount = await _mediator.Send(new GetCarCountQuery());
            var locationCount = await _mediator.Send(new GetLocationCountQuery());
            var brandCount = await _mediator.Send(new GetBrandCountQuery());
            var avgDailyPrice = await _mediator.Send(new GetAvgRentPriceDailyQuery());
            return new Get4StatisticsQueryResult
            {
                AvgDailyPrice = avgDailyPrice.AvgDailyPrice,
                BrandCount = brandCount.BrandCount,
                CarCount = carCount.CarCount,
                LocationCount = locationCount.LocationCount
            };

        }
    }
}
