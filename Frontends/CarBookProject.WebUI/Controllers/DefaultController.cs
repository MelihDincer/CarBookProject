using CarBookProject.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace CarBookProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken").Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync("https://localhost:7063/api/Locations");
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    return Redirect("/error/403");
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Redirect("/Login/Index/");
                }
                else
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                    List<SelectListItem> values2 = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.LocationID.ToString()
                                                    }).ToList();
                    ViewBag.v = values2;
                }

            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(string book_pickdate, string book_off_date, string time_pick, string time_off, string locationID)
        {
            TempData["bookpickdate"] = book_pickdate;
            TempData["bookoffdate"] = book_off_date;
            TempData["timepick"] = time_pick;
            TempData["timeoff"] = time_off;
            TempData["locationID"] = locationID;
            return RedirectToAction("Index", "RentACarList");
        }
    }
}
