using Microsoft.EntityFrameworkCore;

namespace TheaterAdmin.Infrastructure.Persistence
{
    public class TheaterDbContext : DbContext
    {
        public TheaterDbContext(DbContextOptions<TheaterDbContext> options) : base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=localhost,1433; 
        //            Initial Catalog=Theater;User Id=SA;Password=admin123;TrustServerCertificate=True")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
             .Ignore(e => e.Manager);
        }

        public DbSet<Event>? Events { get; set; }

        public DbSet<Manager>? Managers { get; set; }

        public DbSet<Schedule>? Schedules { get; set; }
    }
}
