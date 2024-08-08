using System.Linq.Expressions;

namespace MyPos.WebApi.Repositories.IRepository;

public interface IRepository <T>
{
    T GetById(object id);
    IEnumerable<T> GetAll();

    IQueryable<T> Query();
    IEnumerable<T> Query(Expression<Func<T, bool>> predicate);

    void Insert(T entity);
    void InsertRange(IEnumerable<T> entities);

    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);

    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);

    int Save();
}