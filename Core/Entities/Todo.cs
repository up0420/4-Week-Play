using System;
using Core.Enums;

namespace Core.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public bool IsCompleted { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
