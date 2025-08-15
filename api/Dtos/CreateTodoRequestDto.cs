using System;

namespace Api.Dtos
{
    public class CreateTodoRequestDto
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }  // 서비스는 사용 안 함
    }
}
