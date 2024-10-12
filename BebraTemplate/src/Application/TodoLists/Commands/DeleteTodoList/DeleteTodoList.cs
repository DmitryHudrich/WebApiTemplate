using BebraTemplate.Application.Common.Interfaces;

namespace BebraTemplate.Application.TodoLists.Commands.DeleteTodoList;

public record DeleteTodoListCommand(Int32 Id) : IRequest;

public class DeleteTodoListCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteTodoListCommand> {
    public async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken) {
        var entity = await context.TodoLists
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        context.TodoLists.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);
    }
}
