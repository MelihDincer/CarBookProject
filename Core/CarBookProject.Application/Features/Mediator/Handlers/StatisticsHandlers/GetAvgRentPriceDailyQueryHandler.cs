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
    public class GetAvgRentPriceDailyQueryHandler : IRequestHandler<GetAvgRentPriceDailyQuery, GetAvgRentPriceDailyQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetAvgRentPriceDailyQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetAvgRentPriceDailyQueryResult> Handle(GetAvgRentPriceDailyQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetAvgRentPriceDailyAsync();
            return new GetAvgRentPriceDailyQueryResult { AvgDailyPrice = value };
        }
    }
}
