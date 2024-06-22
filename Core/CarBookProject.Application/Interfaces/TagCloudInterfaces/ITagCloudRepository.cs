using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Interfaces.TagCloudInterfaces;

public interface ITagCloudRepository
{
    Task<List<TagCloud>> GetTagCloudsByBlogIdAsync(int id);
}
