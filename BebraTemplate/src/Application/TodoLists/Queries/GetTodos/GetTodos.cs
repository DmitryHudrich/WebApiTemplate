using BebraTemplate.Application.Common.Interfaces;
using BebraTemplate.Application.Common.Models;
using BebraTemplate.Application.Common.Security;
using BebraTemplate.Domain.Enums;

namespace BebraTemplate.Application.TodoLists.Queries.GetTodos;

[Authorize]
public record GetTodosQuery : IRequest<TodosVm>;

public class GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTodosQuery, TodosVm> {
    public async Task<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken) {
        return new TodosVm {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new LookupDto { Id = (Int32)p, Title = p.ToString() })
                .ToList(),

            Lists = await context.TodoLists
                .AsNoTracking()
                .ProjectTo<TodoListDto>(mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
