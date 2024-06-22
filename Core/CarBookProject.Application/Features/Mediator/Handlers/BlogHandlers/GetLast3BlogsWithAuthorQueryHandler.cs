using CarBookProject.Application.Features.Mediator.Queries.BlogQueries;
using CarBookProject.Application.Features.Mediator.Results.BlogResults;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetLast3BlogsWithAuthorQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorQuery, List<GetLast3BlogsWithAuthorQueryResult>>
{
    private readonly IBlogRepository _repository;

    public GetLast3BlogsWithAuthorQueryHandler(IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetLast3BlogsWithAuthorQueryResult>> Handle(GetLast3BlogsWithAuthorQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetLast3BlogsWithAuthorAsync();
        return values.Select(x => new GetLast3BlogsWithAuthorQueryResult
        {
            Title = x.Title,
            AuthorName = x.Author.Name,
            CategoryName = x.Category.Name,
            CoverImageUrl = x.CoverImageUrl,
            BlogID = x.BlogID,
            CreatedDate = x.CreatedDate,
            Description = x.Description,
        }).ToList();
    }
}
