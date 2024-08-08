using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyPos.WebApi.Repositories.IRepository;

namespace MyPos.WebApi.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class, new()
{
    private DbContext DbContext { get; set; }

    public BaseRepository(DbContext DbContext)
    {
        this.DbContext = DbContext;
    }


    public void Insert(T entity)
    {
        DbContext.Set<T>().Add(entity);
    }
    public void InsertRange(IEnumerable<T> entities)
    {
        DbContext.Set<T>().AddRange(entities);
    }

    public IQueryable<T> Query()
    {
        return DbContext.Set<T>().AsQueryable();
    }
    public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
    {
        return DbContext.Set<T>().Where(predicate);
    }

    public void Update(T entity)
    {
        DbContext.Set<T>().Update(entity);
    }
    public void UpdateRange(IEnumerable<T> entities)
    {
        DbContext.Set<T>().UpdateRange(entities);
    }

    public void Delete(T entity)
    {
        DbContext.Set<T>().Remove(entity);
    }
    public void DeleteRange(IEnumerable<T> entity)
    {
        DbContext.Set<T>().RemoveRange(entity);
    }

    public int Save()
    {
        return DbContext.SaveChanges();
    }

    public IEnumerable<T> GetAll()
    {
        return DbContext.Set<T>().ToList();
    }

    public T GetById(object id)
    {
        return DbContext.Set<T>().Find(id)!;
    }
}