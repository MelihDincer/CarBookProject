using CarBookProject.Application.Features.Mediator.Queries.AuthorQueries;
using CarBookProject.Application.Features.Mediator.Results.AuthorResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.AuthorHandlers;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
{
    private readonly IRepository<Author> _repository;

    public GetAuthorByIdQueryHandler(IRepository<Author> repository)
    {
        _repository = repository;
    }

    public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetAuthorByIdQueryResult
        {
            AuthorID = value.AuthorID,
            Description = value.Description,
            ImageUrl = value.ImageUrl,
            Name = value.Name,
        };
    }
}
