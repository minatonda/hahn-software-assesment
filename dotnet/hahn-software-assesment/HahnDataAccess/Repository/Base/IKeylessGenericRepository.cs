using System.Linq.Expressions;

namespace DataAccess.Repository.Base;
public interface IKeylessGenericRepository<T> where T : class
{
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    IEnumerable<T> GetAll();
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}