using System;
using Core.Enums;

namespace Application.Handlers.Character
{
    public class CreateCharacterCommand
    {
        public Guid UserId { get; }
        public CharacterType Type { get; }
        public required string Name { get; init; }

        public CreateCharacterCommand(Guid userId, CharacterType type, string name)
        {
            UserId = userId;
            Type = type;
            Name = name;
        }
    }
}
