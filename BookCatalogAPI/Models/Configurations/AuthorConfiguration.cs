using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalogAPI.Models.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder
            .HasKey(a => a.Id)
            .HasName("PK_AuthorID");

        builder
            .HasIndex(a => new { a.FirstName, a.LastName })
            .HasDatabaseName("Key_Forename");

        builder
            .Property(a => a.Id)
            .HasColumnType("uuid")
            .HasColumnOrder(0);

        builder
            .Property(a => a.FirstName)
            .HasColumnName("name")
            .HasColumnType("text")
            .HasMaxLength(50);

        builder.Property(a => a.LastName)
            .HasColumnName("forename")
            .HasColumnType("text")
            .HasMaxLength(50);

        builder
            .Property(a => a.CreatedAt)
            .HasColumnType("date")
            .HasPrecision(8);

        builder
            .Property(a => a.UpdatedAt)
            .HasColumnType("date")
            .HasPrecision(8);

        builder
            .Property(a => a.Status)
            .HasColumnType("boolean")
            .HasDefaultValue("true");
    }
}