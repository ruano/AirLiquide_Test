using AirLiquide_Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AirLiquide_Test.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(c =>
            {
                c.ToTable("Cliente");
                c.HasKey(p => p.Id);
                c.Property(p => p.Id).ValueGeneratedOnAdd().HasValueGenerator<GuidGenerator>();
                c.Property(p => p.Nome).HasMaxLength(100);
            });
        }
    }

    public class BloggingContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=airliquide;User Id=sa;Password=sa;");

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}