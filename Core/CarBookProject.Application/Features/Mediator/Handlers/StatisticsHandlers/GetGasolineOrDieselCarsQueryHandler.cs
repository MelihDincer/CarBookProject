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
    public class GetGasolineOrDieselCarsQueryHandler : IRequestHandler<GetGasolineOrDieselCarsQuery, GetGasolineOrDieselCarsQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetGasolineOrDieselCarsQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetGasolineOrDieselCarsQueryResult> Handle(GetGasolineOrDieselCarsQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetGasolineOrDieselCarsAsync();
            return new GetGasolineOrDieselCarsQueryResult { Count = value };
        }
    }
}
