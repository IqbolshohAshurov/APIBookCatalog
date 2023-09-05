using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalogAPI.Models.Configurations;

public class SubjectPublishingConfiguration: IEntityTypeConfiguration<SubjectPublishing>
{
    public void Configure(EntityTypeBuilder<SubjectPublishing> builder)
    {
        builder
            .HasOne(sp => sp.Subject)
            .WithMany(s => s.SubjectPublishings)
            .HasForeignKey(sp => sp.SubjectId);

        builder
            .HasOne(sp => sp.Publishing)
            .WithMany(p => p.SubjectPublishings)
            .HasForeignKey(sp => sp.PublishingId);

        builder
            .HasKey(sp => sp.Id)
            .HasName("PK_SubjectPublishing");

        builder
            .Property(sp => sp.Id)
            .HasColumnType("uuid")
            .HasColumnOrder(0);

    }
}