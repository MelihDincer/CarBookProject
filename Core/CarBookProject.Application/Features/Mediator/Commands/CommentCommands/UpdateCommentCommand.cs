using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.CommentCommands;

public class UpdateCommentCommand : IRequest
{
    public int CommentID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public int BlogID { get; set; }
}
