namespace ChatBotIntegration.Services.IService
{
    public interface IDialogService
    {
        Task<string> ProcessDialogActionAsync(Stream requestBody, CancellationToken cancellationToken);
    }
}