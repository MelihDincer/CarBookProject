using CarBookProject.Application.Features.Mediator.Queries.CommentQueries;
using CarBookProject.Application.Features.Mediator.Results.CommentResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CommentInterfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandlers;

public class GetAllCommentWithBlogQueryHandler : IRequestHandler<GetCommentQuery, List<GetAllCommentWithBlogQueryResult>>
{
    private readonly ICommentRepository _repository;

    public GetAllCommentWithBlogQueryHandler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAllCommentWithBlogQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllCommentsWithBlogAsync();
        return values.Select(x => new GetAllCommentWithBlogQueryResult
        {
            CommentID = x.CommentID,
            Name = x.Name,
            CreatedDate = x.CreatedDate,
            Description = x.Description,
            BlogTitle = x.Blog.Title,
            CategoryName = x.Blog.Category.Name,
            AuthorName = x.Blog.Author.Name
        }).ToList();
    }
}
