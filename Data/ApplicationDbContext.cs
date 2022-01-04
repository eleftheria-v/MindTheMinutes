using Meeting_Minutes.Models;
using Microsoft.EntityFrameworkCore;

namespace Meeting_Minutes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<User> Users { get; set; }



    }
}
