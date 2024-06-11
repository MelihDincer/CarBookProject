using CarBookProject.Application.Interfaces.CarInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.CarRepositories;

public class CarRepository : ICarRepository
{
    private readonly CarBookContext _context;

    public CarRepository(CarBookContext context)
    {
        _context = context;
    }

    public List<Car> GetCarListWithBrands()
    {
        var values = _context.Cars.Include(x => x.Brand).ToList();
        return values;
    }
}
