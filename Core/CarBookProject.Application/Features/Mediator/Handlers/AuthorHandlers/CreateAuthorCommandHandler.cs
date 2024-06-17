using CarBookProject.Application.Features.Mediator.Commands.AuthorCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.AuthorHandlers;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
{
    private readonly IRepository<Author> _repository;

    public CreateAuthorCommandHandler(IRepository<Author> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Author
        {
            ImageUrl = request.ImageUrl,
            Description = request.Description,
            Name = request.Name,
        });
    }
}
