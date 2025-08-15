using System;
using Core.Enums;

namespace Api.Dtos
{
    public class StartSimulationRequestDto
    {
        public Guid UserId { get; set; }
        public Guid CharacterId { get; set; }
        public SimulationType Type { get; set; } = SimulationType.Unknown;
        public string? OptionsJson { get; set; }
    }
}
