using System;
using System.Threading.Tasks;
using Application.Services;

namespace Api.Jobs
{
    public class DailyFortuneJob
    {
        private readonly IFortuneService _fortune;
        private readonly INotificationService _notify;
        private readonly IUserService _users;

        public DailyFortuneJob(
            IFortuneService fortune,
            INotificationService notify,
            IUserService users)
        {
            _fortune = fortune;
            _notify = notify;
            _users = users;
        }

        public async Task RunAsync()
        {
            var userIds = await _users.GetAllUserIdsAsync();
            foreach (var uid in userIds)
            {
                var text = await _fortune.GenerateDailyFortuneAsync(uid);
                await _notify.SendUserNotificationAsync(uid.ToString(), text);
            }
        }
    }
}
