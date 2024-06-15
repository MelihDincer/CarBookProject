using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarInterfaces;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers;

public class GetCarWithBrandQueryHandler
{
    private readonly ICarRepository _repository;

    public GetCarWithBrandQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }

    public List<GetCarWithBrandQueryResult> Handle()
    {
        var values = _repository.GetCarListWithBrands();
        return values.Select(x => new GetCarWithBrandQueryResult
        {
            CarID = x.CarID,
            BrandName = x.Brand.Name,
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
