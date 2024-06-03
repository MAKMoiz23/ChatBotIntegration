using ChatBotIntegration.Models.OrderStatus.Request;
using ChatBotIntegration.Models.OrderStatus.Response;

namespace ChatBotIntegration.Services.IService
{
    public interface IOrderStatusService
    {
        Task<GetOrderStatusResponseDTO> GetOrderStatus(GetOrderStatusRequestDTO model, CancellationToken cancellationToken);
    }
}