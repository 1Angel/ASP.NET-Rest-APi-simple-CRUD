using Microsoft.EntityFrameworkCore;
using SimpleCrudAsp.models;

namespace SimpleCrudAsp.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
    }
}
