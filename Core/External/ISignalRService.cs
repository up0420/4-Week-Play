using System.Threading.Tasks;

namespace Core.External
{
    public interface ISignalRService
    {
        Task SendGlobalNotificationAsync(string message);
        Task SendToUserAsync(string userId, string message);
        Task AddToGroupAsync(string connectionId, string groupName);
        Task RemoveFromGroupAsync(string connectionId, string groupName);
    }
}
