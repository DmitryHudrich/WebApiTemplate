using BebraTemplate.Domain.Entities;

namespace BebraTemplate.Application.Common.Interfaces;

public interface IApplicationDbContext {
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<Int32> SaveChangesAsync(CancellationToken cancellationToken);
}
