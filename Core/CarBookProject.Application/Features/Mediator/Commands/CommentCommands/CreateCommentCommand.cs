using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.CommentCommands;

public class CreateCommentCommand : IRequest
{
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public int BlogID { get; set; }
}
