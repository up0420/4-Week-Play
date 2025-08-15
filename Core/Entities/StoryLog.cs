using Core.Enums;
namespace Core.Entities
{
    public class StoryLog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        // ★ 서비스에서 참조하는 속성
        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
