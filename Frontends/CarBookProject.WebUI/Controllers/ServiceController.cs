using CarBookProject.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.Controllers;

public class ServiceController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ServiceController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Index()
    {
        ViewBag.v1 = "Hizmetler";
        ViewBag.v2 = "Hizmetlerimiz";
        return View();
    }
}
