using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Infrastructure.Extensiosns
{
    /// <summary>
    /// Клас описывающий сервис автоматического добавления миграций в БД
    /// </summary>
    public static class MigrationsExtensions
    {
        public static void ApplyMigrations(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CustomDbContext>();

            // Получаем все миграции
            var pendingMigrations = context.Database.GetPendingMigrations();

            // Проверяем, есть ли новые миграции
            if (pendingMigrations.Any())
            {
                // Применяем миграции
                context.Database.Migrate();
            }
        }
    }
}
