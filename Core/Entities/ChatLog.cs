using Core.Enums;
namespace Core.Entities
{
    public class ChatLog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CharacterId { get; set; }

        // ★ 서비스에서 참조하는 속성
        public string UserMessage { get; set; } = string.Empty;
        public string CharacterResponse { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
