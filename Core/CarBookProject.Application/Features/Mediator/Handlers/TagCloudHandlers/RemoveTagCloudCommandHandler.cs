using CarBookProject.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class RemoveTagCloudCommandHandler : IRequestHandler<RemoveTagCloudCommand>
{
    private readonly IRepository<TagCloud> _repository;

    public RemoveTagCloudCommandHandler(IRepository<TagCloud> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}
