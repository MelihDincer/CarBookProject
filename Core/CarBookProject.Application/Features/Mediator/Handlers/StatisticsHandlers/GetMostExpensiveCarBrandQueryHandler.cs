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
    public class GetMostExpensiveCarBrandQueryHandler : IRequestHandler<GetMostExpensiveCarBrandQuery, GetMostExpensiveCarBrandQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetMostExpensiveCarBrandQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetMostExpensiveCarBrandQueryResult> Handle(GetMostExpensiveCarBrandQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetMostExpensiveCarBrandAsync();
            return new GetMostExpensiveCarBrandQueryResult { BrandName = value };
        }
    }
}
