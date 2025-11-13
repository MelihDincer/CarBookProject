using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.CarPricingRepositories;

public class CarPricingRepository : ICarPricingRepository
{
	private readonly CarBookContext _context;

	public CarPricingRepository(CarBookContext context)
	{
		_context = context;
	}

	public async Task<List<CarPricing>> GetCarPricingWithCarsAsync()
	{
		var values = await _context.CarPricings
			.Include(x => x.Car)
			.ThenInclude(y => y.Brand)
			.Include(z => z.Pricing)
			.Where(q => q.PricingID == 1) //GÜNLÜK
			.ToListAsync();
		return values;
	}
    public async Task<List<CarPricing>> GetCarPricingWithTimePeriodsAsync()
    {
		var values = await _context.CarPricings
			.Include(x => x.Car)
			.ThenInclude(y => y.Brand).ToListAsync();
        return values;
    }

}
