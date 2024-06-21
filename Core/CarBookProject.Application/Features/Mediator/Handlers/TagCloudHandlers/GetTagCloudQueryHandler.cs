using CarBookProject.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBookProject.Application.Features.Mediator.Results.TagCloudResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
{
    private readonly IRepository<TagCloud> _repository;

    public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetTagCloudQueryResult
        {
            TagCloudID = x.TagCloudID,
            BlogID = x.BlogID,
            Name = x.Name
        }).ToList();
    }
}
