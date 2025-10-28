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
    public class GetElectricCarsQueryHandler : IRequestHandler<GetElectricCarsQuery, GetElectricCarsQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetElectricCarsQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetElectricCarsQueryResult> Handle(GetElectricCarsQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetElectricCarsAsync();
            return new GetElectricCarsQueryResult { Count = value };
        }
    }
}
