using CarBookProject.Application.Features.Mediator.Commands.PricingCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.PricingHandlers;

public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
{
    private readonly IRepository<Pricing> _repository;

    public RemovePricingCommandHandler(IRepository<Pricing> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}
