using Microsoft.EntityFrameworkCore;
using shop.web.Entities;

namespace shop.web;

public class Context : DbContext 
{

    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    public DbSet<Item> Items {get; set;}

    public DbSet<Table> Tables {get; set;}

    public DbSet<TableBill> TableBills {get; set;}

}