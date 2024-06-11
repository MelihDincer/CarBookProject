using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarQueryHandler
{
    private readonly IRepository<Car> _repository;

    public GetCarQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCarQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetCarQueryResult
        {
            CarID = x.CarID,
            BrandID = x.BrandID,
            Model = x.Model,
            Seat = x.Seat,
            Transmission = x.Transmission,
            Fuel = x.Fuel,
            Km = x.Km,
            Luggage = x.Luggage,
            CoverImageUrl = x.CoverImageUrl,
            BigImageUrl = x.BigImageUrl       
        }).ToList();
    }
}
