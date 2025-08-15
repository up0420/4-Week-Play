using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;

namespace Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<ChatLog> LogAsync(Guid userId, Guid characterId, string userMessage, string characterResponse)
        {
            var log = new ChatLog
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CharacterId = characterId,
                UserMessage = userMessage,
                CharacterResponse = characterResponse,
                CreatedAt = DateTime.UtcNow
            };

            await _chatRepository.AddAsync(log);
            return log;
        }

        // ★ 핸들러가 호출하는 메서드 이름을 추가로 제공
        public async Task<ChatLog> ChatWithCharacterAsync(Guid userId, Guid characterId, string userMessage)
        {
            // TODO: 실제 LLM 응답 생성 로직 연결
            var characterResponse = string.Empty;
            return await LogAsync(userId, characterId, userMessage, characterResponse);
        }
    }
}
