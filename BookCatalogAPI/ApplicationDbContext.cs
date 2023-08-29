using System.Reflection;
using BookCatalogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogAPI;

public class ApplicationDbContext: DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<Publishing> Publishings { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<BookLanguage> BookLanguages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=BookCatalog;Username=postgres;Password=2359");
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseModel>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Id = Guid.NewGuid();
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}