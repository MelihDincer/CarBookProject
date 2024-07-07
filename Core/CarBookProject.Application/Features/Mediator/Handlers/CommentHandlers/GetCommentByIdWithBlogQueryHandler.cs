using CarBookProject.Application.Features.Mediator.Queries.CommentQueries;
using CarBookProject.Application.Features.Mediator.Results.CommentResults;
using CarBookProject.Application.Interfaces.CommentInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandlers;

public class GetCommentByIdWithBlogQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdWithBlogQueryResult>
{
    private readonly ICommentRepository _repository;

    public GetCommentByIdWithBlogQueryHandler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetCommentByIdWithBlogQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetCommentByIdWithBlogAsync(request.Id);
        return new GetCommentByIdWithBlogQueryResult
        {
            CommentID = value.CommentID,
            Name = value.Name,
            CreatedDate = value.CreatedDate,
            Description = value.Description,
            BlogTitle = value.Blog.Title,
            AuthorName = value.Blog.Author.Name,
            CategoryName = value.Blog.Category.Name
        };
    }
}
