using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class RepositoryContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = ENES\\SQLEXPRESS; Database = AspCoreForumDb; Integrated Security = True; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>()
                     .HasOne(p => p.AppUser)
                     .WithMany(u => u.Posts)
                     .HasForeignKey(p => p.AppUserId)
                     .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Post>()
                   .HasOne(p => p.Topic)
                   .WithMany(u => u.Posts)
                   .HasForeignKey(p => p.TopicID)
                   .OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}
