using CarBookProject.Application.Features.CQRS.Commands.CarCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers;

public class CreateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public CreateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCarCommand command)
    {
        await _repository.CreateAsync(new Car
        {
            BigImageUrl = command.BigImageUrl,
            BrandID = command.BrandID,
            Luggage = command.Luggage,
            Km = command.Km,
            Model = command.Model,
            Seat = command.Seat,
            Transmission = command.Transmission,
            CoverImageUrl = command.CoverImageUrl,
            Fuel = command.Fuel
        });
    }
}
