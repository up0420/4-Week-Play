using Core.Enums; // 이걸로!

namespace Application.Commands.Character
{
    public class CreateCharacterCommand
    {
        public int UserId { get; }
        public CharacterType Type { get; }
        public string Name { get; }

        public CreateCharacterCommand(int userId, CharacterType type, string name)
        {
            UserId = userId;
            Type = type;
            Name = name;
        }
    }
}
