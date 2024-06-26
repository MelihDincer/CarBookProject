﻿using CarBookProject.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
}
