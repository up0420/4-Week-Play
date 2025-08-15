using FluentValidation;
using Application.Handlers.Chat;

namespace Application.Validators
{
    public class ChatWithCharacterCommandValidator : AbstractValidator<ChatWithCharacterCommand>
    {
        public ChatWithCharacterCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.CharacterId).NotEmpty();
            RuleFor(x => x.UserMessage).NotEmpty().MaximumLength(2000);
        }
    }
}
