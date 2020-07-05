using System;
using KodluyoruzEFCoreAPI.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KodluyoruzEFCoreAPI.Data
{
    public class KodluyoruzDbContext : DbContext
    {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public KodluyoruzDbContext(DbContextOptions<KodluyoruzDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(dbLoggerCategory);
            base.OnConfiguring(optionsBuilder);
        }
        private static ILoggerFactory dbLoggerCategory =
            LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information).AddConsole();
            });
    }

    
}
