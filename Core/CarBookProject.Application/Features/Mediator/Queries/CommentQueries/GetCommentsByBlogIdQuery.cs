using CarBookProject.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.CommentQueries;

public class GetCommentsByBlogIdQuery : IRequest<List<GetCommentsByBlogIdWithBlogQueryResult>>
{
    public int Id { get; set; }

    public GetCommentsByBlogIdQuery(int id)
    {
        Id = id;
    }
}
