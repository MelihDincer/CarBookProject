using CarBookProject.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBookProject.Application.Features.Mediator.Results.TagCloudResults;
using CarBookProject.Application.Interfaces.TagCloudInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
{
    private readonly ITagCloudRepository _repository;

    public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetTagCloudsByBlogIdAsync(request.Id);
        return values.Select(x => new GetTagCloudByBlogIdQueryResult
        {
            BlogID = x.BlogID,
            Name = x.Name,
            TagCloudID = x.TagCloudID
        }).ToList();
    }
}
