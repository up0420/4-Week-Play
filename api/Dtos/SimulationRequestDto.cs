namespace Api.Dtos
{
    public class SimulationRequestDto
    {
        public int UserId { get; set; }
        public Core.Enums.SimulationType SimulationType { get; set; }
        public int CharacterId { get; set; }
        // 추가 파라미터 필요시 계속 확장
    }
}
