using System;
using KodluyoruzEFCoreAPI.Objects;
using Microsoft.EntityFrameworkCore;

namespace KodluyoruzEFCoreAPI.Data
{
    public class KodluyoruzDbContext : DbContext
    {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public KodluyoruzDbContext(DbContextOptions<KodluyoruzDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
