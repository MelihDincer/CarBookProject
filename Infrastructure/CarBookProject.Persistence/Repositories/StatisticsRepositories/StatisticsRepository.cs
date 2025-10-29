using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<int> GetAuthorCountAsync()
        {
            return await _context.Authors.CountAsync();
        }

        public async Task<decimal> GetAvgRentPriceDailyAsync()
        {
            int pricingId = Convert.ToInt32(_context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault());
            return await _context.CarPricings.Where(x => x.PricingID == pricingId).AverageAsync(y => y.Amount);
        }
        public async Task<decimal> GetAvgRentPriceMonthlyAsync()
        {
            int pricingId = Convert.ToInt32(_context.Pricings.Where(x => x.Name == "Aylık").Select(y => y.PricingID).FirstOrDefault());
            return await _context.CarPricings.Where(x => x.PricingID == pricingId).AverageAsync(y => y.Amount);
        }
        public async Task<decimal> GetAvgRentPriceWeeklyAsync()
        {
            int pricingId = Convert.ToInt32(_context.Pricings.Where(x => x.Name == "Haftalık").Select(y => y.PricingID).FirstOrDefault());
            return await _context.CarPricings.Where(x => x.PricingID == pricingId).AverageAsync(y => y.Amount);
        }
        public async Task<string> GetMostExpensiveCarBrandAsync()
        {
            int pricingID = Convert.ToInt32(_context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault());
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }
        public async Task<string> GetCheapestCarBrandAsync()
        {
            int pricingID = Convert.ToInt32(_context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault());
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = await _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefaultAsync();
            return brandModel;           
        }
        public async Task<int> GetBlogCountAsync()
        {
            return await _context.Blogs.CountAsync();
        }

        public async Task<string> GetBlogTitleWithMostCommentsAsync()
        {
            var values = await _context.Comments.GroupBy(x => x.BlogID).
                             Select(y => new
                             {
                                 BlogID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefaultAsync();
            string blogName = await _context.Blogs.Where(x => x.BlogID == values.BlogID).Select(y => y.Title).FirstOrDefaultAsync();
            return blogName;
        }
        
        public async Task<string> GetBrandNameWithMostCarsAsync()
        {
            var values = await _context.Cars.GroupBy(x => x.BrandID).
                            Select(y => new
                            {
                                BrandID = y.Key,
                                Count = y.Count()
                            }).OrderByDescending(z => z.Count).Take(1).FirstOrDefaultAsync();
            string brandName = await _context.Brands.Where(x => x.BrandID == values.BrandID).Select(y => y.Name).FirstOrDefaultAsync();
            return brandName;
        }

        public async Task<int> GetCarCountAsync()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<int> GetCarCountByTransmissionIsAutoAsync()
        {
            return await _context.Cars.CountAsync(x => x.Transmission == "Otomatik");
        }

        public async Task<int> GetCarsWithLessThan1000KmAsync()
        {
            return await _context.Cars.CountAsync(x => x.Km <= 1000);
        }
      
        public async Task<int> GetElectricCarsAsync()
        {
            return await _context.Cars.CountAsync(x => x.Fuel == "Hybrid");
        }

        public async Task<int> GetGasolineOrDieselCarsAsync()
        {
            return await _context.Cars.CountAsync(x => x.Fuel == "Dizel" || x.Fuel == "Benzin");
        }

        public async Task<int> GetLocationCountAsync()
        {
            return await _context.Locations.CountAsync();
        }

        public async Task<int> GetBrandCountAsync()
        {
            return await _context.Brands.CountAsync();
        }
    }
}
