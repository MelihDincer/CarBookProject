using CarBookProject.Dto.BrandDtos;
using CarBookProject.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBookProject.WebUI.Controllers;

public class AdminCarController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminCarController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7063/api/Cars/GetCarWithBrand");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> CreateCar()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7063/api/Brands");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            List<SelectListItem> brands = (from x in values
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.BrandId.ToString()
                                           }).ToList();
            ViewBag.brands = brands;
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createCarDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7063/api/Cars", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> RemoveCar(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:7063/api/Cars?id={id}");

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCar(int id)
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessage1 = await client.GetAsync("https://localhost:7063/api/Brands");
        var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
        var values1 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);
        List<SelectListItem> brands = (from x in values1
                                       select new SelectListItem
                                       {
                                           Text = x.Name,
                                           Value = x.BrandId.ToString()
                                       }).ToList();
        ViewBag.brands = brands;

        var response = await client.GetAsync($"https://localhost:7063/api/Cars/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
            return View(values);
        }
        return View();

    }

    [HttpPost]
    public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateCarDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:7063/api/Cars", stringContent);
        if(response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

}
