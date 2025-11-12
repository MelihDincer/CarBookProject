using CarBookProject.Dto.LocationDtos;
using CarBookProject.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7063/api/Locations");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.LocationID.ToString()
                                            }
                                            ).ToList();
            ViewBag.v = values2;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7063/api/Reservations", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SweetAlertType"] = "success";
                TempData["SweetAlertMessage"] = "Rezervasyonunuz başarıyla yapılmıştır. Lütfen e-posta adresinizi kontrol ediniz.";
                TempData["SweetAlertMessageTitle"] = "Rezervasyon Başarıyla Tamamlandı ✅";
                TempData["RedirectUrl"] = "/Default/Index";
                return View();
            }
            TempData["SweetAlertType"] = "error";
            TempData["SweetAlertMessage"] = "Rezervasyon oluşturulurken bilinmeyen bir hata oluştu. Lütfen müşteri temsilcisi ile iletişime geçiniz.";
            TempData["SweetAlertMessageTitle"] = "Rezervasyon Esnasında Hata ile Karşılaşıldı ❌";
            TempData["RedirectUrl"] = "/Reservation/Index";
            return View();

        }
    }
}
