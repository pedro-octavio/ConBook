using CONBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CONBook.Data.Configuration.Tables
{
    public static class BookTable
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(x => x.Id)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(x => x.Name)
                .HasMaxLength(40)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(x => x.Description)
                .HasMaxLength(4200);

            modelBuilder.Entity<Book>()
                .Property(x => x.Details)
                .HasMaxLength(4200);
        }
    }
}
