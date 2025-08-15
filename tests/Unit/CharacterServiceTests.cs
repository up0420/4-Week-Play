using Xunit;
using Application.Services;
using Core.Entities;
using Core.Enums;
using Moq;
using Core.Repositories;

namespace Tests.Unit
{
    public class CharacterServiceTests
    {
        private readonly CharacterService _service;
        private readonly Mock<ICharacterRepository> _characterRepo = new();

        public CharacterServiceTests()
        {
            _service = new CharacterService(_characterRepo.Object);
        }

        [Fact]
        public void 캐릭터_생성_성공()
        {
            // Arrange
            var userId = 1;
            var type = CharacterType.FutureSelf;
            var name = "미래의 나";

            // Act
            var character = _service.CreateCharacter(userId, type, name);

            // Assert
            Assert.NotNull(character);
            Assert.Equal(userId, character.UserId);
            Assert.Equal(type, character.Type);
            Assert.Equal(name, character.Name);
        }
    }
}
