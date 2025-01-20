using System.Linq.Expressions;

namespace DataAccess.Repository.Base;
public interface IGenericRepository<T> : IKeylessGenericRepository<T> where T : class
{
    T GetById(int id);
}