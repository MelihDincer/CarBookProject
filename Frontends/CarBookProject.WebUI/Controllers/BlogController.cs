using CarBookProject.Dto.BlogDtos;
using CarBookProject.Dto.CommentDtos;
using CarBookProject.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers;

public class BlogController : Controller
{
	private readonly IHttpClientFactory _httpClientFactory;

	public BlogController(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<IActionResult> Index()
	{
		ViewBag.v1 = "Bloglar";
		ViewBag.v2 = "Yazarlarımızın Blog Yazıları";
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync("https://localhost:7063/api/Blogs/GetAllBlogsWithAuthorList");
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
			return View(values);
		}
		return View();
	}

	public IActionResult BlogDetail(int id)
	{
        ViewBag.v1 = "Bloglar";
        ViewBag.v2 = "Blog Detayları ve Yorumlar";
		ViewBag.blogid = id; 
        return View();
	}

	[HttpGet]
	public PartialViewResult AddComment(int id)
	{
		return PartialView();
	}

    [HttpPost]
    public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
    {
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(createCommentDto);
		StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
		var responseMessage = await client.PostAsync("https://localhost:7063/api/Comments", stringContent);
		if (responseMessage.IsSuccessStatusCode)
		{
			TempData["SweetAlertType"] = "success";
			TempData["SweetAlertMessageTitle"] = "Yorumunuz yapılmıştır. Teşekkür ederiz ☺️";
			TempData["RedirectUrl"] = $"/Blog/BlogDetail/{createCommentDto.BlogID}";
			
		}
		else
		{
            TempData["SweetAlertType"] = "error";
            TempData["SweetAlertMessageTitle"] = "Yorum yapma esnasında hata ile karşılaşıldı. Lütfen tekrar deneyiniz ❌";
            TempData["RedirectUrl"] = $"/Blog/BlogDetail/{createCommentDto.BlogID}";
        }
			
        return Redirect($"/Blog/BlogDetail/{createCommentDto.BlogID}");
    }
}
