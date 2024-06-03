using ChatBotIntegration.Models.OrderStatus.Request;
using ChatBotIntegration.Models.OrderStatus.Response;
using ChatBotIntegration.Services.IService;
using Newtonsoft.Json;
using System.Text;

namespace ChatBotIntegration.Services.Service
{
    public class OrderStatusService(HttpClient httpClient) : IOrderStatusService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<GetOrderStatusResponseDTO> GetOrderStatus(GetOrderStatusRequestDTO model, CancellationToken cancellationToken)
        {
            string json = new (JsonConvert.SerializeObject(model));

            StringContent content = new(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient
                .PostAsync("api/getOrderStatus", content, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Unable to fetch from api.");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync(cancellationToken);
            var responseObject = JsonConvert.DeserializeObject<GetOrderStatusResponseDTO>(jsonResponse) ?? 
                new GetOrderStatusResponseDTO();

            return responseObject;
        }
    }
}
