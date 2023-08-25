using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalogAPI.Models.Configure;

public class BookLanguageConfiguration: IEntityTypeConfiguration<BookLanguage>
{
    public void Configure(EntityTypeBuilder<BookLanguage> builder)
    {
        builder
            .HasKey(bl => bl.Id)
            .HasName("PK_BookLanguageID");
        
        builder
            .Property(bl => bl.Id)
            .HasColumnType("uuid")
            .HasColumnOrder(0);

        builder
            .Property(bl => bl.BookId)
            .HasColumnType("uuid");

        builder
            .Property(bl => bl.LanguageId)
            .HasColumnType("uuid");

        builder
            .HasOne(bl => bl.Book)
            .WithMany(b => b.BookLanguages)
            .HasForeignKey(bl => bl.BookId);

        builder
            .HasOne(bl => bl.Language)
            .WithMany(l => l.BookLanguages)
            .HasForeignKey(bl => bl.LanguageId);











    }
}