﻿using CarBookProject.Application.Interfaces.CarPricingInterfaces;
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

	public Task<List<CarPricing>> GetCarPricingWithCarsAsync()
	{
		var values = _context.CarPricings
			.Include(x => x.Car)
			.Include(y => y.Car.Brand)
			.Include(z => z.Pricing)
			.Where(q => q.PricingID == 3)
			.ToListAsync();
		return values;
	}

}
