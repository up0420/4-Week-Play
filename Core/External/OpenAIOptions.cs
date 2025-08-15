namespace Core.External
{
    public class OpenAIOptions
    {
        public string ApiKey { get; set; } = string.Empty;
        public string Model { get; set; } = "gpt-4o-mini";
        public double Temperature { get; set; } = 0.7;
    }
}
