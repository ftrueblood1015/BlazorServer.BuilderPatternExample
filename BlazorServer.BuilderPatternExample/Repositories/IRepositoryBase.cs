using BlazorServer.BuilderPatternExample.Domain.Models;

namespace BlazorServer.BuilderPatternExample.Repositories
{
    public interface IRepositoryBase<T>
        where T : BaseModel
    {
        T Add(T entity);

        bool Delete(T entity);

        bool DeleteById(int entityId);

        IEnumerable<T> Filter(Func<T, bool> predicate);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        T? GetById(int id);

        T? GetBySlug(string slug);

        T Update(T entity);
    }
}
