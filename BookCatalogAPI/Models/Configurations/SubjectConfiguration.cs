using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalogAPI.Models.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder
            .HasMany(s => s.Publishings)
            .WithMany(p => p.Subjects)
            .UsingEntity<SubjectPublishing>(s => s.ToTable("SubjectPublishings"));

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


    }
}