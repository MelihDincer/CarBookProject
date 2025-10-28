using CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBookProject.Application.Features.Mediator.Results.StatisticsResults;
using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetCarCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarCountAsync();
            return new GetCarCountQueryResult { CarCount = value };
        }
    }
}
