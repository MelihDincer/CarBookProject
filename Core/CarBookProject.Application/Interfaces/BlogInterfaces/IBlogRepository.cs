using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Interfaces.BlogInterfaces;

public interface IBlogRepository
{
    List<Blog> GetLast3BlogsWithAuthor();
}