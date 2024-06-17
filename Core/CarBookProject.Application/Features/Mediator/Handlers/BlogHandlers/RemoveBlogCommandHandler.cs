using CarBookProject.Application.Features.Mediator.Commands.BlogCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandlers;

public class RemovePricingCommandHandler : IRequestHandler<RemoveBlogCommand>
{
    private readonly IRepository<Blog> _repository;

    public RemovePricingCommandHandler(IRepository<Blog> repository)
    {
        _repository = repository;
    }
    public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}