using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.LocationCommands;

public class CreateLocationCommand : IRequest
{
    public string Name { get; set; }
}
