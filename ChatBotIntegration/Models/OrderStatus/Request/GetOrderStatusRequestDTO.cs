using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ChatBotIntegration.Models.OrderStatus.Request
{
    public class GetOrderStatusRequestDTO
    {
        [JsonProperty("orderId")]
        [Required]
        public string OrderId { get; set; }
    }
}
