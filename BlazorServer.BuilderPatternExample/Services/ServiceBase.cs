using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Repositories;

namespace BlazorServer.BuilderPatternExample.Services
{
    public class ServiceBase<T, TRepo> : IServiceBase<T>
        where T : BaseModel
        where TRepo : IRepositoryBase<T>
    {
        public ServiceBase(IRepositoryBase<T> repo) 
        {
            Repo = repo;
        }
        protected IRepositoryBase<T> Repo { get; }

        public T Add(T entity)
        {
            return Repo.Add(entity);
        }

        public bool Delete(T entity)
        {
            return Repo.Delete(entity);
        }

        public bool DeleteById(int entityId)
        {
            return Repo.DeleteById(entityId);
        }

        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return Repo.Filter(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return Repo.GetAll();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Repo.GetAllAsync();
        }

        public T? GetById(int id)
        {
            return Repo.GetById(id);
        }

        public T? GetBySlug(string slug)
        {
            return Repo.GetBySlug(slug);
        }

        public T Update(T entity)
        {
            return Repo.Update(entity);
        }
    }
}
