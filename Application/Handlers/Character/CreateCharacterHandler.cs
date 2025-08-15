using System.Threading.Tasks;
using Application.Services;

// ★ Core.Entities.Character 를 별칭으로 지정
using CharacterEntity = Core.Entities.Character;
using Application.Handlers.Character; // (있어도 무방)

namespace Application.Handlers.Character
{
    public class CreateCharacterHandler
    {
        private readonly CharacterService _characterService;

        public CreateCharacterHandler(CharacterService characterService)
        {
            _characterService = characterService;
        }

        public async Task<CharacterEntity> Handle(CreateCharacterCommand command)
        {
            return await _characterService.CreateCharacterAsync(
                command.UserId,
                command.Type,
                command.Name);
        }
    }
}
