using CarBookProject.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using System;

namespace CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers;

public class UpdateBannerCommandHandler
{
    private readonly IRepository<Banner> _repository;

    public UpdateBannerCommandHandler(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateBannerCommand command)
    {
        var value = await _repository.GetByIdAsync(command.BannerID);
        value.Description = command.Description;
        value.Title = command.Title;
        value.VideoDescription = command.VideoDescription;
        value.VideoUrl = command.VideoUrl;
        await _repository.UpdateAsync(value);
    }
}
