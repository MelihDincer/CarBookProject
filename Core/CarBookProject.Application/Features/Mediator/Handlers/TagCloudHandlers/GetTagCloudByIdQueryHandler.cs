using CarBookProject.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBookProject.Application.Features.Mediator.Results.TagCloudResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
{
    private readonly IRepository<TagCloud> _repository;

    public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
    {
        _repository = repository;
    }

    public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetTagCloudByIdQueryResult
        {
            BlogID = value.BlogID,
            TagCloudID = value.TagCloudID,
            Name = value.Name
        };
    }
}