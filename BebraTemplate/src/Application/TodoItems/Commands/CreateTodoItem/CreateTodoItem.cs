﻿using BebraTemplate.Application.Common.Interfaces;
using BebraTemplate.Domain.Entities;
using BebraTemplate.Domain.Events;

namespace BebraTemplate.Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand : IRequest<Int32> {
    public Int32 ListId { get; init; }

    public String? Title { get; init; }
}

public class CreateTodoItemCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateTodoItemCommand, Int32> {
    public async Task<Int32> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken) {
        var entity = new TodoItem {
            ListId = request.ListId,
            Title = request.Title,
            Done = false
        };

        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        context.TodoItems.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
