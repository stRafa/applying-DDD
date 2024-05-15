using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NerdStore.Chat.API.Hubs;

namespace NerdStore.Chat.API.Controllers;

[ApiController]
[Route("api/notifications")]
public class NotificationsController : ControllerBase
{
    private readonly IHubContext<ChatHub> _hubContext;

    public NotificationsController(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost]
    public async Task<IActionResult> PostNotification(string mensagem)
    {
        await _hubContext.Clients.Group("grupo").SendAsync("SendMessage", mensagem);
        return Ok();
    }
}