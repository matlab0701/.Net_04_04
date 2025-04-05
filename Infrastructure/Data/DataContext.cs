using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
        .HasMany(a => a.Books)
        .WithOne(b => b.Author)
        .HasForeignKey(b => b.AuthorId);

        modelBuilder.Entity<Book>()
        .HasOne(b => b.Genre)
        .WithMany(g => g.Books)
        .HasForeignKey(b => b.GenreId);

    }


}
