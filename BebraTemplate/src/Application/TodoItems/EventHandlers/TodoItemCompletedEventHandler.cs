using BebraTemplate.Domain.Events;
using Microsoft.Extensions.Logging;

namespace BebraTemplate.Application.TodoItems.EventHandlers;

public class TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger) : INotificationHandler<TodoItemCompletedEvent> {
    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken) {
        logger.LogInformation("BebraTemplate Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
