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
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetBlogByIdQueryResult
        {
            BlogID = value.BlogID,
            AuthorID = value.AuthorID,
            CategoryID = value.CategoryID,
            CoverImageUrl = value.CoverImageUrl,
            CreatedDate = value.CreatedDate,
            Title = value.Title,
            Description = value.Description
        };
    }
}
