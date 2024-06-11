using CarBookProject.Application.Features.Mediator.Queries.FeatureQueries;
using CarBookProject.Application.Features.Mediator.Results.FeatureResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
{
    private readonly IRepository<Feature> _repository;

    public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetFeatureByIdQueryResult
        {
            FeatureID = value.FeatureID,
            Name = value.Name
        };
    }
}
