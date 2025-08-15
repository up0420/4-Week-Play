// api/Services/SignalRService.cs
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Api.Hubs;
using Core.External;

namespace Api.Services
{
    public class SignalRService : ISignalRService
    {
        private readonly IHubContext<NotificationHub> _hub;

        public SignalRService(IHubContext<NotificationHub> hub)
        {
            _hub = hub;
        }

        public async Task SendGlobalNotificationAsync(string message)
            => await _hub.Clients.All.SendAsync("ReceiveNotification", message);

        public async Task SendToUserAsync(string userId, string message)
            => await _hub.Clients.Group(userId).SendAsync("ReceiveNotification", message);

        public async Task AddToGroupAsync(string connectionId, string groupName)
            => await _hub.Groups.AddToGroupAsync(connectionId, groupName);

        public async Task RemoveFromGroupAsync(string connectionId, string groupName)
            => await _hub.Groups.RemoveFromGroupAsync(connectionId, groupName);
    }
}
