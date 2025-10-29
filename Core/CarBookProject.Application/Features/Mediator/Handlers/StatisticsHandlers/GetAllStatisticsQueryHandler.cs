using CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBookProject.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAllStatisticsQueryHandler : IRequestHandler<GetAllStatisticsQuery, GetAllStatisticsQueryResult>
    {
        private readonly IMediator _mediator;

        public GetAllStatisticsQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<GetAllStatisticsQueryResult> Handle(GetAllStatisticsQuery request, CancellationToken cancellationToken)
        {
            var authorCount = await _mediator.Send(new GetAuthorCountQuery());
            var avgDailyPrice = await _mediator.Send(new GetAvgRentPriceDailyQuery());
            var avgMonthlyPrice = await _mediator.Send(new GetAvgRentPriceMonthlyQuery());
            var avgWeeklyPrice = await _mediator.Send(new GetAvgRentPriceWeeklyQuery());
            var blogCount = await _mediator.Send(new GetBlogCountQuery());
            var blogTitle = await _mediator.Send(new GetBlogTitleWithMostCommentQuery());
            var brandCount = await _mediator.Send(new GetBrandCountQuery());
            var brandNameByMostCars = await _mediator.Send(new GetBrandNameWithMostCarsQuery());
            var carCountByAutoTransmission = await _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            var carCount = await _mediator.Send(new GetCarCountQuery());
            var carCountByLessThan1000Km = await _mediator.Send(new GetCarsWithLessThan1000KmQuery());
            var brandNameByCheapestCar = await _mediator.Send(new GetCheapestCarBrandQuery());
            var electricCarCount = await _mediator.Send(new GetElectricCarsQuery());
            var gasolineOrDieselCarCount = await _mediator.Send(new GetGasolineOrDieselCarsQuery());
            var locationCount = await _mediator.Send(new GetLocationCountQuery());
            var brandNameByMostExpensiveCar = await _mediator.Send(new GetMostExpensiveCarBrandQuery());

            return new GetAllStatisticsQueryResult
            {
                AuthorCount = authorCount.Count,
                AvgDailyPrice = avgDailyPrice.AvgDailyPrice,
                AvgMonthlyPrice = avgMonthlyPrice.AvgMonthlyPrice,
                AvgWeeklyPrice = avgWeeklyPrice.AvgWeeklyPrice,
                BlogCount = blogCount.Count,
                BlogTitleByMostComment = blogTitle.BlogTitle,
                BrandCount = brandCount.BrandCount,
                BrandNameByMostCars = brandNameByMostCars.BrandName,
                CarCountByAutoTransmission = carCountByAutoTransmission.Count,
                CarCount = carCount.CarCount,
                CarCountByLessThan1000Km = carCountByLessThan1000Km.Count,
                BrandNameByCheapestCar = brandNameByMostCars.BrandName,
                ElectricCarCount = electricCarCount.Count,
                GasolineOrDieselCarCount = gasolineOrDieselCarCount.Count,
                LocationCount = locationCount.LocationCount,
                BrandNameByMostExpensiveCar = brandNameByMostExpensiveCar.BrandName
            };
        }
    }
}
