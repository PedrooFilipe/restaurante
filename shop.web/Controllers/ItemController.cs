using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.web.Entities;
using shop.web.Interfaces;
using shop.web.ModelView;

namespace shop.web.Controllers;

public class ItemController : Controller
{
    public IItemRepository _itemRepository;

    public ItemController(ItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }


    public IActionResult Index()
    {
        return View();
    }

    private async Task<List<Item>> GetInRepository(string description)
    {
        List<Item> items = new List<Item>();
        if (description != null)
        {
            items = await _itemRepository.ListAsync(x => x.Description.Contains(description)).ToListAsync();
        }
        else
        {
            items = await _itemRepository.ListAsync(null).ToListAsync();
        }

        return items;

    }

    public async Task<IActionResult> ListAsync(string description)
    {
        AddItemToTableViewModel model = new AddItemToTableViewModel();

        model.TableId = 1;
        model.Items = await GetInRepository(description);

        return View(model);
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

    public IActionResult AddItem(OrderItemViewModel model)
    {
        List<OrderItemViewModel> pedidos = (List<OrderItemViewModel>) ViewData["orders"];

        if(pedidos == null) {
            pedidos = new List<OrderItemViewModel>();
        }

        pedidos.Add(new OrderItemViewModel
        {
            ItemId = model.ItemId,
            Quantity = model.Quantity,
            Observations = model.Observations,
        });

        ViewData["orders"] = pedidos;

        return PartialView("_Resume");
    }

}