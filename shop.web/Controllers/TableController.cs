using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.web.Entities;
using shop.web.Interfaces;
using shop.web.ModelView;

namespace shop.web.Controllers;

public class TableController : Controller 
{

    ITableRepository _repository;
    ITableBillRepository _tableBillRepository;

    public TableController(ITableRepository repository, ITableBillRepository tableBillRepository)
    {
        _repository = repository;
        _tableBillRepository = tableBillRepository;
    }


    private async Task<List<Table>> GetInRepository(string name)
    {
        List<Table> tables = new List<Table>();
        if (name != null)
        {
            tables = await _repository.ListAsync(x => x.Name.Contains(name)).ToListAsync();
        }
        else
        {
            tables = await _repository.ListAsync(null).ToListAsync();
        }

        return tables;

    }

    public async Task<IActionResult> Index()
    {
        List<Table> tables = await GetInRepository(null);

        return View(tables);
    }

    public async Task<IActionResult> ListAsync() 
    {
        List<Table> tables = await GetInRepository(null);

        return View(tables);
    }
    
    public async Task<IActionResult> ListPartialAsync(string name) 
    {
        List<Table> tables = await GetInRepository(name);

        return PartialView("_Detail", tables);
    }


    public async Task<IActionResult> OpenTables(OpenTablesViewModel model) 
    {
        try
        {
            DateTime currentTime = DateTime.Now;

            List<Table> selectedTables = await _repository.GetTablesByRange(model.TableIds);

            await _repository.UpdateRange(selectedTables);


            var tableBill = _tableBillRepository.Create(new TableBill {                  
                DateOpen = currentTime,
                Tables = selectedTables});


            return RedirectToRoute($"/Item/List?bill={tableBill.Id}");
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

}