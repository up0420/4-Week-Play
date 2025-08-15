using Core.Enums;

namespace Core.Entities
{
    public class Simulation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CharacterId { get; set; }

        // ★ 서비스에서 참조하는 속성
        public SimulationType Type { get; set; }
        public string OptionsJson { get; set; } = string.Empty;
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
    }
}
