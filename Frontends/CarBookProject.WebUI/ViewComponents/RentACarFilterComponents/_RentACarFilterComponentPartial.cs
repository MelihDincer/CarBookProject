using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(string v)
        {
            v="cemil";
            TempData["value"] = v;
            return View();
        }
    }
}
