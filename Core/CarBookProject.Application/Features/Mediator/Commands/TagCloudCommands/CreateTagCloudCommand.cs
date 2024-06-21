using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.TagCloudCommands;

public class CreateTagCloudCommand : IRequest
{
    public string Name { get; set; }
    public int BlogID { get; set; }
}
