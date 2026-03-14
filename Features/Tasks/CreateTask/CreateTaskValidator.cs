using FluentValidation;

namespace TaskFlow.Api.Features.Tasks.CreateTask;

public class CreateTaskValidator : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Priority)
            .IsInEnum();
    }
}