using Microsoft.EntityFrameworkCore;
using shop.web;
using shop.web.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


string connection = builder.Configuration.GetConnectionString("mySql");

builder.Services.AddDbContext<Context>(opt => opt.UseMySql(connection, ServerVersion.AutoDetect(connection)));
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ITableRepository, TableRespository>();
builder.Services.AddScoped<ITableBillRepository, TableBillRespository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
