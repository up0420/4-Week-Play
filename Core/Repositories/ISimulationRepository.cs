using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface ISimulationRepository
    {
        // 개별 조회: Guid 타입 사용
        Task<Simulation?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        // 사용자별 조회: 페이징 파라미터 추가
        Task<IEnumerable<Simulation>> GetByUserIdAsync(
            Guid userId,
            int pageIndex = 0,
            int pageSize = 50,
            CancellationToken cancellationToken = default
        );

        // 새 엔티티 추가
        Task AddAsync(Simulation simulation, CancellationToken cancellationToken = default);

        // 기존 엔티티 업데이트
        Task UpdateAsync(Simulation simulation, CancellationToken cancellationToken = default);

        // 엔티티를 인자로 받는 삭제
        Task DeleteAsync(Simulation simulation, CancellationToken cancellationToken = default);

        // ID 기반 삭제 오버로드
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}