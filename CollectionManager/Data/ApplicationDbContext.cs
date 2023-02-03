using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollectionManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Ithem> Ithems { get; set; }
        public DbSet<IthemTag> IthemTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<IthemLike> IthemLikes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //            new User { Name = "Admin", Active = true, Email = "Admin@mail.com", Language = "En" },
        //            new User { Name = "Bob" }
        //    );
        //}
    }
}