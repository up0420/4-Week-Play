using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;

namespace Application.Services
{
    public interface ICharacterService
    {
        Task<List<Character>> GetUserCharactersAsync(Guid userId);
        Task<Character> CreateCharacterAsync(Guid userId, CharacterType type, string name);
    }
}
