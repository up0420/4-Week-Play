using System;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Services
{
    public interface IChatService
    {
        Task<ChatLog> ChatWithCharacterAsync(Guid userId, Guid characterId, string userMessage);
    }
}
