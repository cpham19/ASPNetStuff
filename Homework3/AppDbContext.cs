using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Homework3.Models;

namespace Homework3.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forum>().HasKey(f => new { f.ForumId });
            modelBuilder.Entity<Topic>().HasKey(t => new { t.TopicId });
            modelBuilder.Entity<Reply>().HasKey(r => new { r.ReplyId });
        }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
    }
}
