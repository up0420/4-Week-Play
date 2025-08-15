using FluentValidation;
using Application.Handlers.Character;
using Core.Enums;

namespace Application.Validators
{
    public class CreateCharacterCommandValidator : AbstractValidator<CreateCharacterCommand>
    {
        public CreateCharacterCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Type).IsInEnum();
        }
    }
}
