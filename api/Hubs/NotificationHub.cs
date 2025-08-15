using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Api.Hubs
{
    public class NotificationHub : Hub
    {
        // 사용자가 그룹(예: 유저별 알림 채널)에 가입
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        // 그룹에서 탈퇴
        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        // 특정 사용자에게 알림 전송
        public async Task SendNotificationToUser(string userId, string message)
        {
            await Clients.User(userId).SendAsync("ReceiveNotification", message);
        }

        // 그룹(예: 관리자, 특정 유저 그룹)에 알림 전송
        public async Task SendNotificationToGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveNotification", message);
        }

        // 전체에게 알림 전송 (필요하다면)
        public async Task SendNotificationToAll(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }

        // 허브에 연결될 때(예: 로그인/인증 기반 추가 동작)
        public override async Task OnConnectedAsync()
        {
            // TODO: 필요 시 연결된 유저 정보 처리
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // TODO: 필요 시 연결 해제 처리
            await base.OnDisconnectedAsync(exception);
        }
    }
}
