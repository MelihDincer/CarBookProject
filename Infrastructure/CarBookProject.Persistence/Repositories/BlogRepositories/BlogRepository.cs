using CarBookProject.Application.Interfaces.BlogInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.BlogRepositories;

public class BlogRepository : IBlogRepository
{
	private readonly CarBookContext _context;

	public BlogRepository(CarBookContext context)
	{
		_context = context;
	}

	public Task<List<Blog>> GetAllBlogsWithAuthorAsync()
	{
		var values = _context.Blogs
			.Include(x => x.Author)
			.Include(y => y.Category)
			.OrderByDescending(z => z.BlogID)
			.ToListAsync();
		return values;
	}

	public Task<List<Blog>> GetLast3BlogsWithAuthorAsync()
	{
		var values = _context.Blogs
			.Include(x => x.Author)
			.Include(y => y.Category)
			.OrderByDescending(z => z.BlogID)
			.Take(3)
			.ToListAsync();
		return values;
	}
}
