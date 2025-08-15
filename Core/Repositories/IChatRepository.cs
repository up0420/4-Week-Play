using Core.Entities;

namespace Core.Repositories
{
    public interface IChatRepository
    {
        // ★ ChatService에서 호출
        Task AddAsync(ChatLog chatLog);
    }
}
