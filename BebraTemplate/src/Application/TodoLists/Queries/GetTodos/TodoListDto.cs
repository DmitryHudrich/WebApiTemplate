using BebraTemplate.Domain.Entities;

namespace BebraTemplate.Application.TodoLists.Queries.GetTodos;

public class TodoListDto {
    public TodoListDto() {
        Items = [];
    }

    public Int32 Id { get; init; }

    public String? Title { get; init; }

    public String? Colour { get; init; }

    public IReadOnlyCollection<TodoItemDto> Items { get; init; }

    private class Mapping : Profile {
        public Mapping() {
            CreateMap<TodoList, TodoListDto>();
        }
    }
}
