using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.web.Entities;
using shop.web.Interfaces;
using shop.web.ModelView;

namespace shop.web.Controllers;

public class OrderController : Controller
{
    public IItemRepository _orderRepository;

    public OrderController(ItemRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }


    public IActionResult Index()
    {
        return View();
    }



    public async Task<IActionResult> CreateAsync(OrderViewModel model)
    {



        return Ok(model);

    }


    private async Task<List<Item>> GetInRepository(string description)
    {
        List<Item> items = new List<Item>();
        if (description != null)
        {
            items = await _orderRepository.ListAsync(x => x.Description.Contains(description)).ToListAsync();
        }
        else
        {
            items = await _orderRepository.ListAsync(null).ToListAsync();
        }

        return items;

    }

    public async Task<IActionResult> ListAsync(string description)
    {
        var items = await GetInRepository(description);


        return View(items);
    }

    public async Task<IActionResult> ListPartial(string description)
    {
        var items = await GetInRepository(description);
        return PartialView("_Detail", items);
    }

    public IActionResult OpenTables() 
    {
        return Ok();
    }


    public IActionResult ChangeStatus() 
    {
        return Ok();
    }

}