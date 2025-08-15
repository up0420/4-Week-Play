using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SimulationRepository : ISimulationRepository
    {
        private readonly AppDbContext _context;

        public SimulationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Simulation?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            // FindAsync에 CancellationToken 전달
            var key = new object[] { id };
            var entry = await _context.Simulations.FindAsync(key, cancellationToken);
            return entry;
        }

        public async Task<IEnumerable<Simulation>> GetByUserIdAsync(
            Guid userId,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            return await _context.Simulations
                                 .Where(x => x.UserId == userId)
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Simulation simulation, CancellationToken cancellationToken = default)
        {
            await _context.Simulations.AddAsync(simulation, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Simulation simulation, CancellationToken cancellationToken = default)
        {
            _context.Simulations.Update(simulation);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Simulation simulation, CancellationToken cancellationToken = default)
        {
            _context.Simulations.Remove(simulation);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var simulation = await GetByIdAsync(id, cancellationToken);
            if (simulation != null)
            {
                await DeleteAsync(simulation, cancellationToken);
            }
        }
    }
}