using Microsoft.AspNetCore.Mvc;

namespace shop.web.Controllers;

public class TableController : Controller 
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult List() 
    {
        return View();
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