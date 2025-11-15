using CarBookProject.Application.Features.Mediator.Queries.BlogQueries;
using CarBookProject.Application.Features.Mediator.Results.BlogResults;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetBlogByIdWithAuthorQueryHandler : IRequestHandler<GetBlogByIdWithAuthorQuery, GetBlogByIdWithAuthorQueryResult>
{
    private readonly IBlogRepository _repository;

    public GetBlogByIdWithAuthorQueryHandler(IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetBlogByIdWithAuthorQueryResult> Handle(GetBlogByIdWithAuthorQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetBlogByIdWithAuthorAsync(request.Id);
        return new GetBlogByIdWithAuthorQueryResult
        {
            BlogID = value.BlogID,
            AuthorDescription = value.Author.Description,
            AuthorImageUrl = value.Author.ImageUrl,
            AuthorName = value.Author.Name,
            CoverImageUrl = value.CoverImageUrl,
            CreatedDate = value.CreatedDate,
            Title = value.Title,
            Description = value.Description
        };
    }
}
