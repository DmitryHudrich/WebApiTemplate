using BebraTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BebraTemplate.Infrastructure.Data.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem> {
    public void Configure(EntityTypeBuilder<TodoItem> builder) {
        builder.Property(static t => t.Title)
            .HasMaxLength(200)
            .IsRequired();
    }
}
