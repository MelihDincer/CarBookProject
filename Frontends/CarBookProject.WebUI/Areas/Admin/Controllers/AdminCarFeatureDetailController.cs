using CarBookProject.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7063/api/CarFeatures?carId={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            foreach (var item in resultCarFeatureByCarIdDto)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7063/api/CarFeatures/CarFeatureChangeAvailableToTrue?id={item.CarFeatureID}");
                    //return RedirectToAction("Index", "AdminCar");
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7063/api/CarFeatures/CarFeatureChangeAvailableToFalse?id={item.CarFeatureID}");
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }
    }
}
