namespace ChatBotIntegration.Models.Webhook
{
    public class FulfillmentMessage
    {
        public FulfillemntText Text { get; set; }
    }

    public class FulfillemntText
    {
        public List<string> Text { get; set; } = new List<string>();
    }
}
