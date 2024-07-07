using CarBookProject.Dto.BlogDtos;
using CarBookProject.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class AdminCommentController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminCommentController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7063/api/Comments/GetCommentsByBlogIdWithBlog?id={id}");
        var response2 = await client.GetAsync($"https://localhost:7063/api/Blogs/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultBlogByIdDto>(jsonData2);
            ViewBag.blogtitle = value.Title;
            return View(values);
        }
        return View();
    }
}
