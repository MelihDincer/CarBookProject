using CarBookProject.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBookProject.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardCarPricingListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardCarPricingListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v1 = "Araç Fiyat Paketleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7063/api/CarPricings/GetCarPricingWithTimePeriod");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithTimePeriod>>(jsonData);
                var last5Values = values.OrderByDescending(x => x.Id).Take(6).ToList();
                return View(last5Values);
            }
            return View();
        }
    }
}
