using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;

namespace Application.Services
{
    public class SimulationService : ISimulationService
    {
        public Task<Simulation> StartSimulationAsync(Guid userId, Guid characterId, SimulationType type, string? optionsJson)
        {
            var sim = new Simulation
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CharacterId = characterId,
                Type = type,
                OptionsJson = optionsJson ?? string.Empty,
                StartedAt = DateTime.UtcNow
            };
            return Task.FromResult(sim);
        }

        // 컨트롤러가 type/옵션을 안 넘기는 경우 대비
        public Task<Simulation> StartSimulationAsync(Guid userId, Guid characterId)
            => StartSimulationAsync(userId, characterId, SimulationType.Unknown, null);

        public Task<List<Simulation>> GetUserSimulationsAsync(Guid userId)
            => Task.FromResult(new List<Simulation>());
    }
}
