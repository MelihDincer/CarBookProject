using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces.CarInterfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers;

public class GetLast5CarsWithBrandQueryHandler 
{
    private readonly ICarRepository _repository;

    public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }

    public List<GetLast5CarsWithBrandQueryResult> Handle()
    {
        var values = _repository.GetLast5CarsWithBrands();
        return values.Select(x=> new GetLast5CarsWithBrandQueryResult
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
