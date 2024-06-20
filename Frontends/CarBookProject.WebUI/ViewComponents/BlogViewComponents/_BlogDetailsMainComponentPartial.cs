using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailsMainComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
