using CONBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CONBook.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
