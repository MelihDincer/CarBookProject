using CarBookProject.Application.Interfaces.TagCloudInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.TagCloudRepositories;

public class TagCloudRepository : ITagCloudRepository
{
    private readonly CarBookContext _context;

    public TagCloudRepository(CarBookContext context)
    {
        _context = context;
    }

    public async Task<List<TagCloud>> GetTagCloudsByBlogIdAsync(int id)
    {
        var values = await _context.TagClouds.Where(x=>x.BlogID == id).ToListAsync();
        return values;
    }
}
