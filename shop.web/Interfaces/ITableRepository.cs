using shop.web.Entities;

namespace shop.web.Interfaces;

public interface ITableRepository : IGenericRepository<Table>
{

    Task UpdateRange(List<Table> tables);

    Task<List<Table>> GetTablesByRange(List<int> ids);


}