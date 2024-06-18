using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries;

public class GetCarPricingWithCarQuery : IRequest<List<GetCarPricingWithCarQueryResult>>
{
}
