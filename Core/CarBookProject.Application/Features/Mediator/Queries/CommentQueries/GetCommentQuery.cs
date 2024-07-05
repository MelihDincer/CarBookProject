using CarBookProject.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.CommentQueries;

public class GetCommentQuery : IRequest<List<GetAllCommentWithBlogQueryResult>>
{
}
