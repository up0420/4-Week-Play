using System.Threading.Tasks;
using Core.External;

namespace Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ISignalRService _signalR;
        public NotificationService(ISignalRService signalR) => _signalR = signalR;

        public Task SendUserNotificationAsync(string userId, string message)
            => _signalR.SendToUserAsync(userId, message);

        public Task SendGlobalNotificationAsync(string message)
            => _signalR.SendGlobalNotificationAsync(message);
    }
}
