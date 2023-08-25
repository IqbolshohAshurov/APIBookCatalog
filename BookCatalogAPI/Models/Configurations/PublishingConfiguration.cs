using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalogAPI.Models.Configure;

public class PublishingConfiguration: IEntityTypeConfiguration<Publishing>
{
    public void Configure(EntityTypeBuilder<Publishing> builder)
    {
        builder
            .HasKey(p => p.Id)
            .HasName("PK_PublishingID");
        
        builder
            .HasIndex(p => p.Name)
            .HasDatabaseName("Key_PublishingName");
        
        builder
            .Property(p => p.Id)
            .HasColumnType("uuid")
            .HasColumnOrder(0);
        
        builder
            .Property(p => p.Name)
            .HasColumnType("text")
            .HasMaxLength(100);

        builder
            .Property(p => p.CityId)
            .HasColumnType("uuid");


    }
}