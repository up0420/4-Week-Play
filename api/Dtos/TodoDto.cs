using System;

namespace Api.Dtos
{
    public class TodoDto
    {
        public Guid Id { get; set; }                    // ← Guid
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
