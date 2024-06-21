using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.TagCloudCommands;

public class UpdateTagCloudCommand : IRequest
{
    public int TagCloudID { get; set; }
    public string Name { get; set; }
    public int BlogID { get; set; }
}
