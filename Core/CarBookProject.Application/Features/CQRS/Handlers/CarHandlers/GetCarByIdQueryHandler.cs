using CarBookProject.Application.Features.CQRS.Queries.CarQueries;
using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarByIdQueryHandler
{
    private readonly IRepository<Car> _repository;

    public GetCarByIdQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);
        return new GetCarByIdQueryResult
        {
            CarID = value.CarID,
            BrandID = value.BrandID,
            Model = value.Model,
            Seat = value.Seat,
            Transmission = value.Transmission,
            Fuel = value.Fuel,
            Km = value.Km,
            Luggage = value.Luggage,
            CoverImageUrl = value.CoverImageUrl,
            BigImageUrl = value.BigImageUrl
        };
    }
}
