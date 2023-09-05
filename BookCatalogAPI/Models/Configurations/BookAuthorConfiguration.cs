using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalogAPI.Models.Configurations;

public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder
            .HasKey(ba => ba.Id)
            .HasName("PK_BookAuthorID");

        builder
            .Property(ba => ba.Id)
            .HasColumnType("uuid")
            .HasColumnOrder(0);

        builder
            .Property(ba => ba.BookId)
            .HasColumnType("uuid");

        builder
            .Property(ba => ba.AuthorId)
            .HasColumnType("uuid");

        // relation between Book and Author
        builder
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookId);

        builder
            .HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId);
    }
}