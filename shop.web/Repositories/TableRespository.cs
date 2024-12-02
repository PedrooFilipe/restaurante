using shop.web.Entities;
using shop.web.Interfaces;
using shop.web;
using shop.web.Reposirories;
using Microsoft.EntityFrameworkCore;

public class TableRespository : GenericRepository<Table>, ITableRepository
{
    private Context _context;
    public TableRespository(Context context) : base(context)
    {
        _context = context;
    }

    public async Task UpdateRange(List<Table> tables)
    {
        _context.UpdateRange(tables);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Table>> GetTablesByRange(List<int> ids)
    {
        return await _context.Tables.Where(x => ids.Contains(x.Id)).AsNoTracking().ToListAsync();
    }
}