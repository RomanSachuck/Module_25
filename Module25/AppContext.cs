using Microsoft.EntityFrameworkCore;
using Module25.Entities;

namespace Module25
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-KVCJ0H9\SQLEXPRESS; Database = Test; Trusted_Connection = True;TrustServerCertificate = true;");
        }
    }
}
