using CarBookProject.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.CommentQueries;

public class GetCommentByIdQuery : IRequest<GetCommentByIdWithBlogQueryResult>
{
    public int Id { get; set; }

    public GetCommentByIdQuery(int id)
    {
        Id = id;
    }
}
