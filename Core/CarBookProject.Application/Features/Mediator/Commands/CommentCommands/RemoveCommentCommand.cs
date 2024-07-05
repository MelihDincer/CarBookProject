using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.CommentCommands;

public class RemoveCommentCommand : IRequest
{
    public int Id { get; set; }

    public RemoveCommentCommand(int id)
    {
        Id = id;
    }
}
