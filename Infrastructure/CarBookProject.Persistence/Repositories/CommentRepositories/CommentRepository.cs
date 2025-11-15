using CarBookProject.Application.Interfaces.CommentInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.CommentRepositories;

public class CommentRepository : ICommentRepository
{
    private readonly CarBookContext _context;

    public CommentRepository(CarBookContext context)
    {
        _context = context;
    }

    public Task<List<Comment>> GetAllCommentsWithBlogAsync()
    {
        var values = _context.Comments
            .Include(x => x.Blog)
            .Include(y => y.Blog.Author)
            .Include(z => z.Blog.Category)
            .ToListAsync();
        return values;
    }

    public Task<Comment> GetCommentByIdWithBlogAsync(int id)
    {
        var value = _context.Comments
            .Include(x => x.Blog)
            .Include(y => y.Blog.Author)
            .Include(z => z.Blog.Category)
            .FirstOrDefaultAsync(x => x.BlogID == id);
        return value;
    }

    public Task<int> GetCommentCount(int id)
    {
        var value = _context.Comments.CountAsync(x => x.BlogID == id);
        return value;
    }

    public Task<List<Comment>> GetCommentsByBlogIdWithBlogAsync(int id)
    {
        var values = _context.Comments
            .Include(x => x.Blog)
            .Include(y => y.Blog.Author)
            .Include(z => z.Blog.Category)
            .Where(k => k.BlogID == id)
            .ToListAsync();
        return values;
    }
}
