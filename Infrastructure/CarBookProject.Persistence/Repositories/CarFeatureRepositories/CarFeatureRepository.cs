using CarBookProject.Application.Interfaces.CarFeatureInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarFeature>> GetCarFeaturesByCarID(int carID)
        {
            var carFeatures = await _context.CarFeatures.Include(x => x.Feature).Where(y => y.CarID == carID).ToListAsync();
            return carFeatures;               
        }
    }
}
