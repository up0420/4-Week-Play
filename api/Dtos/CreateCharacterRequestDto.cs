using System;
using Core.Enums;

namespace Api.Dtos
{
    public class CreateCharacterRequestDto
    {
        public Guid UserId { get; set; }
        public CharacterType Type { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
