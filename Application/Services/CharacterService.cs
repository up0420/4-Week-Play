using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;
using Core.Repositories;

namespace Application.Services
{
    public class CharacterService : ICharacterService
    {
        public async Task<List<Character>> GetUserCharactersAsync(Guid userId)
            => await GetCharactersByUserAsync(userId); // 기존 메서드 재사용
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<List<Character>> GetCharactersByUserAsync(Guid userId)
            => (await _characterRepository.GetCharactersByUserIdAsync(userId)).ToList();

        public async Task<Character> CreateCharacterAsync(Guid userId, CharacterType type, string name)
        {
            var ch = new Character
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Type = type,
                Name = name,
                State = string.Empty,
                PersonaPrompt = string.Empty,
                YinYangRate = string.Empty
            };
            await _characterRepository.AddAsync(ch);
            return ch;
        }
    }
}
