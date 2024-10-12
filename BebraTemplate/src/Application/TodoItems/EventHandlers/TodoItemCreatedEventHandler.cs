using BebraTemplate.Domain.Events;
using Microsoft.Extensions.Logging;

namespace BebraTemplate.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger) : INotificationHandler<TodoItemCreatedEvent> {
    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken) {
        logger.LogInformation("BebraTemplate Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
