using CarBookProject.Dto.LoginDtos;
using CarBookProject.Dto.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createLoginDto);
        //    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("https://localhost:7063/api/Register", content);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        TempData["SuccessMessage"] = "Kayıt başarıyla yapılmıştır. İyi günler dileriz ☺️";
        //    }
        //    return View();
        //}
    }
}
