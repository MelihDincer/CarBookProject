using CarBookProject.Application.Features.Mediator.Commands.AuthorCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.AuthorHandlers;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
{
    private readonly IRepository<Author> _repository;

    public UpdateAuthorCommandHandler(IRepository<Author> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.AuthorID);
        value.Description = request.Description;
        value.Name = request.Name;
        value.ImageUrl = request.ImageUrl;
        await _repository.UpdateAsync(value);
    }
}
