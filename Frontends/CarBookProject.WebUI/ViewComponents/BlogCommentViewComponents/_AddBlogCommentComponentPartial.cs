using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.BlogCommentViewComponents;

public class _AddBlogCommentComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return  View();
    }
}
