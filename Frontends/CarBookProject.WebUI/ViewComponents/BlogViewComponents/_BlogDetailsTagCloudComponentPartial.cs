using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailsTagCloudComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
