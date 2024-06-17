using CarBookProject.Application.Features.Mediator.Queries.BlogQueries;
using CarBookProject.Application.Features.Mediator.Results.BlogResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandlers;

public class GetPricingByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
{
    private readonly IRepository<Blog> _repository;
    public GetPricingByIdQueryHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }

    public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        return new GetBlogByIdQueryResult
        {
            BlogID = values.BlogID,
            AuthorID = values.AuthorID,
            CategoryID = values.CategoryID,
            CoverImageUrl = values.CoverImageUrl,
            CreatedDate = values.CreatedDate,
            Title = values.Title
        };
    }
}
