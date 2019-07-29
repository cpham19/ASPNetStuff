using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Contact>().HasKey(c => new { c.ContactId});
        }
    }
}
