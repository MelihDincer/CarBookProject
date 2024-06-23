namespace CarBookProject.Application.Features.RepositoryPattern;

public interface IGenericRepository<T> where T : class
{
    List<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Remove(T entity);
    void Update(T entity);
}
