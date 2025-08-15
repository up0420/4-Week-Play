using FluentValidation;
using Application.Handlers.Todo;

namespace Application.Validators
{
    public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        }
    }
}
