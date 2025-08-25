namespace Api.Dtos
{
    public class SimulationResultDto
    {
        public int SimulationId { get; set; }
        public string ResultSummary { get; set; } = string.Empty;
        public DateTime RunAt { get; set; }
    }
}
