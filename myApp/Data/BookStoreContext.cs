using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace myApp.Data
{
    public class BookStoreContext : IdentityDbContext<AppUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }
        #region dbSet
        public DbSet<Book>? Books { get; set; }
        #endregion
    }
}
