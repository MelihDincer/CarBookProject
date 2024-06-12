using CarBookProject.Application.Features.Mediator.Commands.LocationCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.LocationHandlers;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public CreateLocationCommandHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Location
        {
            Name = request.Name
        });
    }
}
