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
    public class GetCheapestCarBrandQueryHandler : IRequestHandler<GetCheapestCarBrandQuery, GetCheapestCarBrandQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetCheapestCarBrandQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetCheapestCarBrandQueryResult> Handle(GetCheapestCarBrandQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetCheapestCarBrandAsync();
            return new GetCheapestCarBrandQueryResult { BrandName = value };
        }
    }
}
