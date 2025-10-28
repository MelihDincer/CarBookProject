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
    public class GetBlogTitleWithMostCommentQueryHandler : IRequestHandler<GetBlogTitleWithMostCommentQuery, GetBlogTitleWithMostCommentQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetBlogTitleWithMostCommentQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetBlogTitleWithMostCommentQueryResult> Handle(GetBlogTitleWithMostCommentQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetBlogTitleWithMostCommentsAsync();
            return new GetBlogTitleWithMostCommentQueryResult { BlogTitle = value };
        }
    }
}
