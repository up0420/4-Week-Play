using System;

namespace Api.Dtos
{
    public class ChatWithCharacterRequestDto
    {
        public Guid UserId { get; set; }
        public Guid CharacterId { get; set; }
        // 컨트롤러에서 Message 이름으로 읽던 것까지 호환
        public string UserMessage { get; set; } = string.Empty;
        public string Message { get => UserMessage; set => UserMessage = value; }
    }
}
