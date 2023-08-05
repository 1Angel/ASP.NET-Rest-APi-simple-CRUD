using Microsoft.EntityFrameworkCore;
using SimpleCrudAsp.models;

namespace SimpleCrudAsp.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }   


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(e => e.Comments)
                .WithOne(e => e.Post)
                .HasForeignKey(e => e.PostId)
                .IsRequired();

        }
    }
}
