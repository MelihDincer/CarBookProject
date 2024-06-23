using CarBookProject.Application.Features.RepositoryPattern;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;

namespace CarBookProject.Persistence.Repositories.CommentRepositories;

public class CommentRepository<T> : IGenericRepository<Comment>
{
    private readonly CarBookContext _context;

    public CommentRepository(CarBookContext context)
    {
        _context = context;
    }

    public void Add(Comment entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public List<Comment> GetAll()
    {
        return _context.Comments.ToList();
    }

    public Comment GetById(int id)
    {
        return _context.Comments.Find(id);
    }

    public void Remove(Comment entity)
    {
        var value = _context.Comments.Find(entity.CommentID);
        _context.Remove(value);
        _context.SaveChanges();
    }

    public void Update(Comment entity)
    {
        _context.Update(entity);
        _context.SaveChanges();
    }
}
