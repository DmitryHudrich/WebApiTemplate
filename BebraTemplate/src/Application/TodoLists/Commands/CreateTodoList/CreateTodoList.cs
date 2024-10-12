using BebraTemplate.Application.Common.Interfaces;
using BebraTemplate.Domain.Entities;

namespace BebraTemplate.Application.TodoLists.Commands.CreateTodoList;

public record CreateTodoListCommand : IRequest<Int32> {
    public String? Title { get; init; }
}

public class CreateTodoListCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateTodoListCommand, Int32> {
    public async Task<Int32> Handle(CreateTodoListCommand request, CancellationToken cancellationToken) {
        var entity = new TodoList {
            Title = request.Title
        };

        context.TodoLists.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
