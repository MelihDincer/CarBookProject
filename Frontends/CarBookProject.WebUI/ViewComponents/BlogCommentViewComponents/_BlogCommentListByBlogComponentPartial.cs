using CarBookProject.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.BlogCommentViewComponents;

public class _BlogCommentListByBlogComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogCommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7063/api/Comments/GetCommentsByBlogIdWithBlog?id={id}");
        
        if (responseMessage.IsSuccessStatusCode)
        {            
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);

            var responseMessage2 = await client.GetAsync($"https://localhost:7063/api/Comments/GetCommentCountByBlogId?id={id}");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultCommentCountDto>(jsonData2);
            ViewBag.commentCount = value.CommentCount;
            return View(values);
        }
        return View();
    }
}
