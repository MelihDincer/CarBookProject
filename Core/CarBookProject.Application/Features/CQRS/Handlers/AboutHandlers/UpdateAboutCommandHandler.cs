using CarBookProject.Application.Features.CQRS.Commands.AboutCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers;

public class UpdateAboutCommandHandler
{
    private readonly IRepository<About> _repository;

    public UpdateAboutCommandHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAboutCommand command)
    {
        var value = await _repository.GetByIdAsync(command.AboutID);
        value.Description = command.Description;
        value.ImageUrl = command.ImageUrl;
        value.Title = command.Title;
        await _repository.UpdateAsync(value);
    }
}
