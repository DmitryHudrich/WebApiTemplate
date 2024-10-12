using BebraTemplate.Application.Common.Interfaces;
using BebraTemplate.Application.Common.Security;
using BebraTemplate.Domain.Constants;

namespace BebraTemplate.Application.TodoLists.Commands.PurgeTodoLists;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.CanPurge)]
public record PurgeTodoListsCommand : IRequest;

public class PurgeTodoListsCommandHandler(IApplicationDbContext context) : IRequestHandler<PurgeTodoListsCommand> {
    public async Task Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken) {
        context.TodoLists.RemoveRange(context.TodoLists);

        await context.SaveChangesAsync(cancellationToken);
    }
}
