namespace Api.Dtos
{
    public class FortuneResponseDto
    {
        public string TodayFortune { get; set; } = string.Empty;
        public List<string> Keywords { get; set; } = new();
        public DateTime GeneratedAt { get; set; }
    }
}
