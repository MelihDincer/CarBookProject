using CarBookProject.Application.Features.Mediator.Queries.BlogQueries;
using CarBookProject.Application.Features.Mediator.Results.BlogResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetServiceQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
{
    private readonly IRepository<Blog> _repository;
    public GetServiceQueryHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetBlogQueryResult
        {
            BlogID = x.BlogID,
            AuthorID = x.AuthorID,
            CategoryID = x.CategoryID,
            CoverImageUrl = x.CoverImageUrl,
            CreatedDate = x.CreatedDate,
            Title = x.Title
        }).ToList();
    }
}
