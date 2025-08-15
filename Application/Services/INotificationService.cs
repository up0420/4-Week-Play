using System.Threading.Tasks;
namespace Application.Services
{
    public interface INotificationService
    {
        Task SendUserNotificationAsync(string userId, string message);
        Task SendGlobalNotificationAsync(string message);
    }
}
