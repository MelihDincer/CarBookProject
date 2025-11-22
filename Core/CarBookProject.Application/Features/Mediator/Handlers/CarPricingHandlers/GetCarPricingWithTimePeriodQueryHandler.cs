using CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.GetCarPricingWithTimePeriodsAsync();
            var result = values
        .GroupBy(x => new { ModelName = x.Car.Model, BrandName = x.Car.Brand.Name, CoverImageUrl = x.Car.CoverImageUrl })
        .Select(g => new GetCarPricingWithTimePeriodQueryResult
        {
            Id = g.Select(x => x.CarPricingID).FirstOrDefault(),
            Model = $"{g.Key.BrandName} {g.Key.ModelName}",
            DailyAmount = g.FirstOrDefault(p => p.PricingID == 1)?.Amount ?? 0,
            WeeklyAmount = g.FirstOrDefault(p => p.PricingID == 2)?.Amount ?? 0,
            MonthlyAmount = g.FirstOrDefault(p => p.PricingID == 3)?.Amount ?? 0,
            CoverImageUrl = g.Key.CoverImageUrl
        })
        .ToList();
            return result;
        }
    }
}
