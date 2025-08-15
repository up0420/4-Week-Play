using System;

namespace Application.Handlers.Todo
{
    public class CreateTodoCommand
    {
        public Guid UserId { get; }
        public required string Title { get; init; }

        public CreateTodoCommand(Guid userId, string title)
        {
            UserId = userId;
            Title = title;
        }
    }
}
