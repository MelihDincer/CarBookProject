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
    public class GetBrandCountQueryHandler : IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetBrandCountQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetBrandCountAsync();
            return new GetBrandCountQueryResult { BrandCount = value };
        }
    }
}
