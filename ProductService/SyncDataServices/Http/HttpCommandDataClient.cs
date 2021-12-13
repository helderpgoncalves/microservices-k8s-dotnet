using ProductService.Dtos;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace ProductService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient

    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendProductToUser(ProductReadDto productDto)
        {
            var content = new StringContent(JsonSerializer.Serialize(productDto), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error sending product to user: {response.StatusCode}");
            } else {
                System.Console.WriteLine($"--> Post with success: {response.StatusCode}");
            }
        }
    }
}