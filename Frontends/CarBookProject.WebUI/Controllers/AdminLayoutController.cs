using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminHeaderPartial()
        {
            return View();
        }

        public IActionResult AdminNavbarPartial()
        {
            return View();
        }

        public IActionResult AdminSidebarPartial()
        {
            return View();
        }
    }
}
