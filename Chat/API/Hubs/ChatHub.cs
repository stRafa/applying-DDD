using Microsoft.AspNetCore.SignalR;

namespace NerdStore.Chat.API.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string group, string user, string message)
    {
        await Clients.Group(group).SendAsync("ReceiveMessage", user, message);
    }

    public async Task JoinGroup(string user, string group)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, group);

        await Clients.Group(group).SendAsync("ReceiveMessage", "Server", $"{user} Connection: {Context.ConnectionId} joined group {group}");
    }
}