using ChatBotIntegration.Models.OrderStatus.Request;
using ChatBotIntegration.Services.IService;
using Google.Cloud.Dialogflow.V2;
using Google.Protobuf;

namespace ChatBotIntegration.Services.Service
{
    public class DialogService : IDialogService
    {
        private readonly IOrderStatusService _orderStatusService;
        private static readonly JsonParser _jsonParser = new(JsonParser.Settings.Default.WithIgnoreUnknownFields(true));

        public DialogService(
            IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        public async Task<string> ProcessDialogActionAsync(Stream requestBody, CancellationToken cancellationToken)
        {
            string requestJson;
            try
            {
                using (TextReader reader = new StreamReader(requestBody))
                {
                    requestJson = await reader.ReadToEndAsync(cancellationToken);
                }

                WebhookRequest request = _jsonParser.Parse<WebhookRequest>(requestJson);
                var pas = request.QueryResult.Parameters;

                bool hasOrderID = pas.Fields.ContainsKey("number") && pas.Fields["number"]
                    .ToString()
                    .Replace('\"', ' ')
                    .Trim().Length > 0;

                WebhookResponse response = new();

                if (!hasOrderID)
                {
                    //response.FulfillmentText = "No order ID provided!";
                    response.FulfillmentMessages.Add(new Intent.Types.Message
                    {
                        Text = new Intent.Types.Message.Types.Text
                        {
                            Text_ = { "No order ID provided!" }
                        }
                    });
                }
                else
                {
                    var orderID = pas.Fields["number"]
                        .ToString()
                        .Replace('\"', ' ')
                        .Trim();

                    var result = await _orderStatusService
                        .GetOrderStatus(new GetOrderStatusRequestDTO { OrderId = orderID }, cancellationToken);

                    //response.FulfillmentText = $"Your order ID {orderID} will be shipped on {result.ShipmentDate}";
                    response.FulfillmentMessages.Add(new Intent.Types.Message
                    {
                        Text = new Intent.Types.Message.Types.Text
                        {
                            Text_ = { $"Your order ID {orderID} will be shipped on {result.ShipmentDate:dddd, dd MMM yyyy}" }
                        }
                    });

                }

                return response.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}