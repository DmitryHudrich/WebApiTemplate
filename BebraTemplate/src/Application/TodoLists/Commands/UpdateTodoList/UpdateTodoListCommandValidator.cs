using BebraTemplate.Application.Common.Interfaces;

namespace BebraTemplate.Application.TodoLists.Commands.UpdateTodoList;

public class UpdateTodoListCommandValidator : AbstractValidator<UpdateTodoListCommand> {
    private readonly IApplicationDbContext context;

    public UpdateTodoListCommandValidator(IApplicationDbContext context) {
        this.context = context;

        RuleFor(static v => v.Title)
            .NotEmpty()
            .MaximumLength(200)
            .MustAsync(BeUniqueTitle)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");
    }

    public async Task<Boolean> BeUniqueTitle(UpdateTodoListCommand model, String title, CancellationToken cancellationToken) {
        return await context.TodoLists
            .Where(l => l.Id != model.Id)
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
