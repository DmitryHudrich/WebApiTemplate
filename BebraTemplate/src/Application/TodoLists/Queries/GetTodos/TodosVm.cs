using BebraTemplate.Application.Common.Models;

namespace BebraTemplate.Application.TodoLists.Queries.GetTodos;

public class TodosVm {
    public IReadOnlyCollection<LookupDto> PriorityLevels { get; init; } = [];

    public IReadOnlyCollection<TodoListDto> Lists { get; init; } = [];
}
