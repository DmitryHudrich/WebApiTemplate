using BebraTemplate.Application.Common.Interfaces;

namespace BebraTemplate.Application.TodoLists.Commands.CreateTodoList;

public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand> {
    private readonly IApplicationDbContext context;

    public CreateTodoListCommandValidator(IApplicationDbContext context) {
        this.context = context;

        RuleFor(static v => v.Title)
            .NotEmpty()
            .MaximumLength(200)
            .MustAsync(BeUniqueTitle)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");
    }

    public async Task<Boolean> BeUniqueTitle(String title, CancellationToken cancellationToken) {
        return await context.TodoLists
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
