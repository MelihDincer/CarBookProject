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
    public class GetBrandNameWithMostCarsQueryHandler : IRequestHandler<GetBrandNameWithMostCarsQuery, GetBrandNameWithMostCarsQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetBrandNameWithMostCarsQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetBrandNameWithMostCarsQueryResult> Handle(GetBrandNameWithMostCarsQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetBrandNameWithMostCarsAsync();
            return new GetBrandNameWithMostCarsQueryResult { BrandName = value };
        }
    }
}
