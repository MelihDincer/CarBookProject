using CarBookProject.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.TagCloudQueries;

public class GetTagCloudByBlogIdQuery : IRequest<List<GetTagCloudByBlogIdQueryResult>>
{
    public int Id { get; set; }

    public GetTagCloudByBlogIdQuery(int id)
    {
        Id = id;
    }
}
