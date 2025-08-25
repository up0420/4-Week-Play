namespace Api.Dtos
{
    public class NotificationDto
    {
        public string Message { get; set; } = string.Empty;
        public Core.Enums.NotificationType Type { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
