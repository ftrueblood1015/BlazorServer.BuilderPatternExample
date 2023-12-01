using BlazorServer.BuilderPatternExample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Principal;
using System.Xml.Linq;

namespace BlazorServer.BuilderPatternExample.Repositories
{
    public class RepositoryBase<T, TContext> : IRepositoryBase<T>
        where T : BaseModel
        where TContext : DbContext
    {
        public TContext Context { get; private set; }
        public RepositoryBase(TContext context) 
        { 
            Context = context;
        }

        public T Add(T entity)
        {
            _ = Context.Set<T>().Add(entity);

            Context.SaveChanges();

            return GetById(entity.Id.GetValueOrDefault())!;
        }

        public bool Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            var results = Context.SaveChanges();

            return results > 0;
        }

        public bool DeleteById(int entityId)
        {
            var entity = Filter(x => x.Id == entityId).Single();

            Context.Set<T>().Remove(entity);
            var results = Context.SaveChanges();

            return results > 0;
        }

        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return Context.Set<T>().AsNoTracking().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            var result = Context.Set<T>();
            return result;
        }

        public T? GetById(int id)
        {
            return Context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T Update(T entity)
        {
            Context.Set<T>().Update(entity);
            Context.SaveChanges();

            return GetById(entity.Id.GetValueOrDefault())!;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public T? GetBySlug(string slug)
        {
            return Context.Set<T>().FirstOrDefault(x => x.Slug == slug);
        }
    }
}
