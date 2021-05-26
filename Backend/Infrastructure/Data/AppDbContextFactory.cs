using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Backend.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            const string connection = "Host=localhost;Port=5432;Database=db;Username=postgres;Password=password";
            var assembly = typeof(AppDbContext).Assembly.FullName;
            optionsBuilder.UseNpgsql(connection, builder => builder.MigrationsAssembly(assembly));
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}