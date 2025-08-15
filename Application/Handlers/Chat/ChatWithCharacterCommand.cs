using System;

namespace Application.Handlers.Chat
{
    public class ChatWithCharacterCommand
    {
        public Guid UserId { get; }
        public Guid CharacterId { get; }
        public required string UserMessage { get; init; }

        public ChatWithCharacterCommand(Guid userId, Guid characterId, string userMessage)
        {
            UserId = userId;
            CharacterId = characterId;
            UserMessage = userMessage;
        }
    }
}
