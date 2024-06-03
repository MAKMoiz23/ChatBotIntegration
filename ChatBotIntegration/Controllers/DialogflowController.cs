using ChatBotIntegration.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace ChatBotIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogflowController : ControllerBase
    {
        private readonly IDialogService _dialogService;
        private readonly ILogger<DialogflowController> _logger;

        public DialogflowController(ILogger<DialogflowController> logger, IDialogService dialogService)
        {
            _logger = logger;
            _dialogService = dialogService;
        }

        [HttpPost]
        public async Task<IActionResult> DialogAction(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Running webhook..");
            string responseJson = await _dialogService.ProcessDialogActionAsync(Request.Body, cancellationToken);
            return Content(responseJson, "application/json");
        }
    }
}
