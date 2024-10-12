using BebraTemplate.Domain.Entities;

namespace BebraTemplate.Application.TodoLists.Queries.GetTodos;

public class TodoItemDto {
    public Int32 Id { get; init; }

    public Int32 ListId { get; init; }

    public String? Title { get; init; }

    public Boolean Done { get; init; }

    public Int32 Priority { get; init; }

    public String? Note { get; init; }

    private class Mapping : Profile {
        public Mapping() {
            CreateMap<TodoItem, TodoItemDto>().ForMember(static d => d.Priority,
                static opt => opt.MapFrom(static s => (Int32)s.Priority));
        }
    }
}
