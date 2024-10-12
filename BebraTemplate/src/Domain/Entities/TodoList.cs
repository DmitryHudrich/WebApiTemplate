namespace BebraTemplate.Domain.Entities;

public class TodoList : BaseAuditableEntity {
    public String? Title { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<TodoItem> Items { get; private set; } = [];
}
