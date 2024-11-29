using Microsoft.EntityFrameworkCore;
using shop.web.Interfaces;
using System.Linq.Expressions;

namespace shop.web.Reposirories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private Context _context;

    public GenericRepository(Context context) 
    {
        _context = context;
    }

    public IQueryable<T> ListAsync(Expression<Func<T, bool>> expression)
    {
        var query = _context.Set<T>().AsQueryable();

        if(expression != null)
        {
           query = query.Where(expression);
        }

        //Fazer paginação
        var teste = query.Skip(0).Take(10);

        return teste;
    } 

    public async Task<T> FindByIdasync(Expression<Func<T, bool>> expression, bool tracking)
    {

        var query = _context.Set<T>().Where(expression);

        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        return await query.SingleOrDefaultAsync();

    }

    public async Task Create(T entity) 
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity) 
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity) 
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}