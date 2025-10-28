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
    public class GetCarsWithLessThan1000KmQueryHandler : IRequestHandler<GetCarsWithLessThan1000KmQuery, GetCarsWithLessThan1000KmQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetCarsWithLessThan1000KmQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetCarsWithLessThan1000KmQueryResult> Handle(GetCarsWithLessThan1000KmQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetCarsWithLessThan1000KmAsync();
            return new GetCarsWithLessThan1000KmQueryResult { Count = value };
        }
    }
}
