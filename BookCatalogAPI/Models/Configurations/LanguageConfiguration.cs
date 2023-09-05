using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalogAPI.Models.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder
            .HasKey(l => l.Id)
            .HasName("PK_LanguageID");

        builder
            .HasIndex(l => l.Name)
            .HasDatabaseName("Key_LanguageName")
            .IsUnique();

        builder
            .Property(l => l.Id)
            .HasColumnType("uuid")
            .HasColumnOrder(0);

        builder
            .Property(l => l.Name)
            .HasColumnType("text")
            .HasMaxLength(40);
    }
}