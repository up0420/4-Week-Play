namespace Api.Dtos
{
    public class SimulationResultDto
    {
        public int SimulationId { get; set; }
        public string ResultSummary { get; set; }
        public DateTime RunAt { get; set; }
    }
}
