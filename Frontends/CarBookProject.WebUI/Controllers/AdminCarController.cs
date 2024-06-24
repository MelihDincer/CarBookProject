using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers;

public class AdminCarController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    
}
