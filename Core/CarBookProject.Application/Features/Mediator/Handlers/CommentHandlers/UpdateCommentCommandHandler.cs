using CarBookProject.Application.Features.Mediator.Commands.CommentCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandlers;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
{
    private readonly IRepository<Comment> _repository;

    public UpdateCommentCommandHandler(IRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.CommentID);
        value.Description = request.Description;
        value.Name = request.Name;
        value.Description = request.Description;
        value.BlogID = request.BlogID;
        await _repository.UpdateAsync(value);
    }
}
