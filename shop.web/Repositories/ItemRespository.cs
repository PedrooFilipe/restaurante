using shop.web.Entities;
using shop.web.Interfaces;
using shop.web;
using System.Linq.Expressions;
using shop.web.Reposirories;

public class ItemRepository : GenericRepository<Item>, IItemRepository
{
    public ItemRepository(Context context) : base(context)
    {

    }
}