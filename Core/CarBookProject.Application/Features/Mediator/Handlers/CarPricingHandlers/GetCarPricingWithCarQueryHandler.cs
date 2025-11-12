using CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarPricingHandlers;

public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
{
	private readonly ICarPricingRepository _repository;

	public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
	{
		_repository = repository;
	}

	public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
	{
		var values = await _repository.GetCarPricingWithCarsAsync();
		return values.Select(x => new GetCarPricingWithCarQueryResult
		{
			CarID = x.CarID,
			Amount = x.Amount,
			BrandName = x.Car.Brand.Name,
			CarPricingID = x.CarPricingID,
			CoverImageUrl = x.Car.CoverImageUrl,
			Model = x.Car.Model,
			PricingName = x.Pricing.Name
		}).ToList();
	}
}
