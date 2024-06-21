using CarBookProject.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.TagCloudQueries;

public class GetTagCloudByIdQuery : IRequest<GetTagCloudByIdQueryResult>
{
    public int Id { get; set; }

    public GetTagCloudByIdQuery(int id)
    {
        Id = id;
    }
}
