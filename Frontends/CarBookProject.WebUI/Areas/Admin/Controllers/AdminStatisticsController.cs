using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminStatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
