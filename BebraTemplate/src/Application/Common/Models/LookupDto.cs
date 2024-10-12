using BebraTemplate.Domain.Entities;

namespace BebraTemplate.Application.Common.Models;

public class LookupDto {
    public Int32 Id { get; init; }

    public String? Title { get; init; }

    private class Mapping : Profile {
        public Mapping() {
            CreateMap<TodoList, LookupDto>();
            CreateMap<TodoItem, LookupDto>();
        }
    }
}
