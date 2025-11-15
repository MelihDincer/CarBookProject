using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Interfaces.CommentInterfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllCommentsWithBlogAsync();
    Task<List<Comment>> GetCommentsByBlogIdWithBlogAsync(int id);
    Task<Comment> GetCommentByIdWithBlogAsync(int id);
    Task<int> GetCommentCount(int id);
}
