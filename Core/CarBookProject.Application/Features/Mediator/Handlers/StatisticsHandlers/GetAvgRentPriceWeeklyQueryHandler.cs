using CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBookProject.Application.Features.Mediator.Results.StatisticsResults;
using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgRentPriceWeeklyQueryHandler : IRequestHandler<GetAvgRentPriceWeeklyQuery, GetAvgRentPriceWeeklyQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetAvgRentPriceWeeklyQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetAvgRentPriceWeeklyQueryResult> Handle(GetAvgRentPriceWeeklyQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetAvgRentPriceWeeklyAsync();
            return new GetAvgRentPriceWeeklyQueryResult { AvgWeeklyPrice = value };
        }
    }
}
