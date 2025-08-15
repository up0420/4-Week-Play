using Core.Enums;
namespace Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Nickname { get; set; } = default!; // 추가
        public string Gender { get; set; } = default!;
        public ICollection<Character> Characters { get; set; } = new List<Character>();
        public ICollection<ChatLog> ChatLogs { get; set; } = new List<ChatLog>();
        public ICollection<StoryLog> StoryLogs { get; set; } = new List<StoryLog>();
        public ICollection<Todo> Todos { get; set; } = new List<Todo>();
        public ICollection<Simulation> Simulations { get; set; } = new List<Simulation>();
    }
}
