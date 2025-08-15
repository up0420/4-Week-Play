using System;

namespace Api.Dtos
{
    public class CharacterDto
    {
        public Guid Id { get; set; }                    // ← Guid
        public string Name { get; set; } = string.Empty;
    }
}
