using CarBookProject.Application.Features.Mediator.Commands.CommentCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandlers;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
{
    private readonly IRepository<Comment> _repository;

    public CreateCommentCommandHandler(IRepository<Comment> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Comment
        {
            BlogID = request.BlogID,
            CreatedDate = DateTime.UtcNow,
            Description = request.Description,
            Name = request.Name,
            Email = request.Email
        });
    }
}
