using CarBookProject.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandlers;

public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand>
{
    private readonly IRepository<TagCloud> _repository;

    public CreateTagCloudCommandHandler(IRepository<TagCloud> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new TagCloud
        {
            BlogID = request.BlogID,
            Name = request.Name
        });
    }
}
