using Core.Enums;
namespace Core.Entities
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PersonaPrompt { get; set; } = string.Empty;
        public string YinYangRate { get; set; } = string.Empty;
        public Core.Enums.CharacterType Type { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

        // ★ 서비스에서 참조하는 속성 추가
        public string State { get; set; } = string.Empty;

        public ICollection<ChatLog> ChatLogs { get; set; } = new List<ChatLog>();
        public ICollection<Simulation> Simulations { get; set; } = new List<Simulation>();
    }
}
