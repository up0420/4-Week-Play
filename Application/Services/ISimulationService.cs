using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;

namespace Application.Services
{
    public interface ISimulationService
    {
        Task<Simulation> StartSimulationAsync(Guid userId, Guid characterId, SimulationType type, string? optionsJson);
        Task<List<Simulation>> GetUserSimulationsAsync(Guid userId);
    }
}
