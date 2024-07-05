using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Interfaces.CommentInterfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllCommentsWithBlogAsync();
}
