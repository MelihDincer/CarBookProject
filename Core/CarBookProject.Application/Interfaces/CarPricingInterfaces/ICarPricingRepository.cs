using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Interfaces.CarPricingInterfaces;

public interface ICarPricingRepository
{
	Task<List<CarPricing>> GetCarPricingWithCarsAsync();
}
