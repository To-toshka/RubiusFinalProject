using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinalProject.Infrastructure
{
    /// <summary>
    /// Класс регистрации настроек класса CustomDbContext.
    /// </summary>
    public class CustomDbContextFactory : IDesignTimeDbContextFactory<CustomDbContext>
    {
        public CustomDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<CustomDbContext>();
            optionBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=postgres;Database=postgres");

            return new CustomDbContext(optionBuilder.Options);
        }
    }
}
