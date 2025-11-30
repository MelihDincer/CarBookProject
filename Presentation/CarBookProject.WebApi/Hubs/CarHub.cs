using CarBookProject.WebApi.Models.CarHubModels;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace CarBookProject.WebApi.Hubs
{
    public class CarHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7063/api/Statistics/GetCarCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();  
            var value = JsonConvert.DeserializeObject<ResultCarCount>(jsonData);
            await Clients.All.SendAsync("ReceiveCarCount", value.CarCount);  
        }
    }
}
