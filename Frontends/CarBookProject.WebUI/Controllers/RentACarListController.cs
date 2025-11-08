using CarBookProject.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id) //LocationId
        {
            ViewBag.v1 = "Aranan Araçlar";
            ViewBag.v2 = "Size Uygun Araçların Listesi";

            //var bookpickdate = TempData["bookpickdate"];
            //var bookoffdate = TempData["bookoffdate"];
            //var timepick = TempData["timepick"];
            //var timeoff = TempData["timeoff"];
            var locationID = TempData["locationID"];
            //filterRentACarDto.LocationID = Convert.ToInt32(locationID.ToString());
            //filterRentACarDto.Available = true;
            //ViewBag.bookpickdate = bookpickdate;
            //ViewBag.bookoffdate = bookoffdate;
            //ViewBag.timepick = timepick;
            //ViewBag.timeoff = timeoff;
            ViewBag.locationID = locationID;
            id = int.Parse(locationID.ToString());
            var client = _httpClientFactory.CreateClient();
            //Available değerini queryden göndermemize gerek kalmadı, çünkü api de boş ise true dön şekilde bir şart koyuldu.Default olarak true gelecek.(Eğer nullable yapılmasaydı defaultta false geliyordu.)
            var responseMessage = await client.GetAsync($"https://localhost:7063/api/RentACars/GetRentACarListByLocation?locationID={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
