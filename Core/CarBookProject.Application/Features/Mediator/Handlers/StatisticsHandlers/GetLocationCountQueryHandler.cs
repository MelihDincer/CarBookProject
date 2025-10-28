using CarBookProject.Application.Features.Mediator.Queries.LocationQueries;
using CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBookProject.Application.Features.Mediator.Results.LocationResults;
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
    public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetLocationCountQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
      
        public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetLocationCountAsync();
            return new GetLocationCountQueryResult { LocationCount = value };
        }
    }
}
