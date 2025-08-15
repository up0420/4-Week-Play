namespace Api.Dtos
{
    public class FortuneResponseDto
    {
        public string TodayFortune { get; set; }
        public string[] Keywords { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}
