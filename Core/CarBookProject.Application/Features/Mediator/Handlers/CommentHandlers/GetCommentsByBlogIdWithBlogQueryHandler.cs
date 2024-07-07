using CarBookProject.Application.Features.Mediator.Queries.CommentQueries;
using CarBookProject.Application.Features.Mediator.Results.CommentResults;
using CarBookProject.Application.Interfaces.CommentInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandlers;

public class GetCommentsByBlogIdWithBlogQueryHandler : IRequestHandler<GetCommentsByBlogIdQuery, List<GetCommentsByBlogIdWithBlogQueryResult>>
{
    private readonly ICommentRepository _repository;

    public GetCommentsByBlogIdWithBlogQueryHandler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCommentsByBlogIdWithBlogQueryResult>> Handle(GetCommentsByBlogIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetCommentsByBlogIdWithBlogAsync(request.Id);
        return values.Select(x => new GetCommentsByBlogIdWithBlogQueryResult
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
