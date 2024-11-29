using System.Linq.Expressions;

namespace shop.web.Interfaces;

public interface IGenericRepository<T>
{

    IQueryable<T> ListAsync(Expression<Func<T, bool>> expression);

    Task<T> FindByIdasync(Expression<Func<T, bool>> expression, bool tracking);

    Task Create(T entity);

    Task Update(T entity);

    Task Delete(T entity); 

}