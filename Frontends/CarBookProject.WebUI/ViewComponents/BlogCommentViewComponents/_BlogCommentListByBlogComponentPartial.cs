using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.BlogCommentViewComponents;

public class _BlogCommentListByBlogComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
