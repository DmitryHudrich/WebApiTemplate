﻿namespace BebraTemplate.Domain.Events;

public class TodoItemCreatedEvent(TodoItem item) : BaseEvent {
    public TodoItem Item { get; } = item;
}
