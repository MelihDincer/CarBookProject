using CarBookProject.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
{
    private readonly IRepository<SocialMedia> _repository;

    public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}
