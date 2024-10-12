namespace BebraTemplate.Domain.Entities;

public class TodoItem : BaseAuditableEntity {
    public Int32 ListId { get; set; }

    public String? Title { get; set; }

    public String? Note { get; set; }

    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    public Boolean Done {
        get => Done1;
        set {
            if (value && !Done1) {
                AddDomainEvent(new TodoItemCompletedEvent(this));
            }

            Done1 = value;
        }
    }

    public TodoList List { get; set; } = null!;
    public Boolean Done1 { get; set; }
}
