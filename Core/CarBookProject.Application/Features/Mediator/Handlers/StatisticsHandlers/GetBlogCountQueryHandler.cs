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
    public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetBlogCountQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetBlogCountAsync();
            return new GetBlogCountQueryResult { Count = value };
        }
    }
}
