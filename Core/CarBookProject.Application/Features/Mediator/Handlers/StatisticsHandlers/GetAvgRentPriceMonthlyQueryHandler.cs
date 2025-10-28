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
    public class GetAvgRentPriceMonthlyQueryHandler : IRequestHandler<GetAvgRentPriceMonthlyQuery, GetAvgRentPriceMonthlyQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetAvgRentPriceMonthlyQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetAvgRentPriceMonthlyQueryResult> Handle(GetAvgRentPriceMonthlyQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetAvgRentPriceMonthlyAsync();
            return new GetAvgRentPriceMonthlyQueryResult { AvgMonthlyPrice = value };
        }
    }
}
