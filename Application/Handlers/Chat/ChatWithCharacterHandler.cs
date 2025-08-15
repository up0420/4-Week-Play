using System.Threading.Tasks;
using Application.Services;
using Core.Entities;

namespace Application.Handlers.Chat
{
    public class ChatWithCharacterHandler
    {
        private readonly ChatService _chatService;

        public ChatWithCharacterHandler(ChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task<ChatLog> Handle(ChatWithCharacterCommand command)
        {
            return await _chatService.ChatWithCharacterAsync(
                command.UserId,
                command.CharacterId,
                command.UserMessage);
        }
    }
}
