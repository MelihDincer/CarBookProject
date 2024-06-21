using CarBookProject.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
{
    private readonly IRepository<TagCloud> _repository;

    public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.TagCloudID);
        value.BlogID = request.BlogID;
        value.Name = request.Name;
        await _repository.UpdateAsync(value);
    }
}
