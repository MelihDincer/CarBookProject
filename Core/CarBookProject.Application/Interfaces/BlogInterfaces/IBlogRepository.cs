using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Interfaces.BlogInterfaces;

public interface IBlogRepository
{
    Task<List<Blog>> GetLast3BlogsWithAuthorAsync();
    Task<List<Blog>> GetAllBlogsWithAuthorAsync();
    Task<Blog> GetBlogByIdWithAuthorAsync(int id);
}