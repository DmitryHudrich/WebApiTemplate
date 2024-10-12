using BebraTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BebraTemplate.Infrastructure.Data.Configurations;

public class TodoListConfiguration : IEntityTypeConfiguration<TodoList> {
    public void Configure(EntityTypeBuilder<TodoList> builder) {
        builder.Property(static t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .OwnsOne(static b => b.Colour);
    }
}
