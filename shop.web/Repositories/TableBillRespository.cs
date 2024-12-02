using shop.web.Entities;
using shop.web.Interfaces;
using shop.web;
using System.Linq.Expressions;
using shop.web.Reposirories;

public class TableBillRespository : GenericRepository<TableBill>, ITableBillRepository
{
    public TableBillRespository(Context context) : base(context)
    {

    }
}