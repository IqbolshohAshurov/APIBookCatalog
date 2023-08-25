using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalogAPI.Models.Configure;

public class SubjectConfiguration: IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder
            .HasKey(s => s.Id)
            .HasName("PK_GenreID");
        
        builder
            .HasIndex(s => s.Title)
            .HasDatabaseName("Key_TitleGenre")
            .IsUnique();

        builder
            .Property(s => s.Id)
            .HasColumnType("uuid")
            .HasColumnOrder(0);
        
        builder
            .Property(s => s.Title)
            .HasColumnName("name")
            .HasColumnType("text")
            .HasMaxLength(100);

        builder
            .Property(s => s.PublishingId)
            .HasColumnType("uuid");

    }
}