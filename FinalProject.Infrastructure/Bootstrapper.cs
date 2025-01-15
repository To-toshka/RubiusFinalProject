using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Domain;
using FinalProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Infrastructure
{
    /// <summary>
    /// Класс регистрации зависимостей в слое Infrastructure.
    /// </summary>
    public static class Bootstrapper
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=postgres";
            services.AddDbContext<CustomDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IEntitiesRepository<User>, UserRepository>();
            services.AddScoped<IEntitiesRepository<Operator>, OperatorRepository>();
            services.AddScoped<IEntitiesRepository<Payment>, PaymentRepository>();
            services.AddScoped<IEntitiesRepository<Reservation>, ReservationRepository>();
            services.AddScoped<IEntitiesRepository<Ticket>, TicketRepository>();
            services.AddScoped<IEntitiesRepository<TicketData>, TicketDataRepository>();

            return services;            
        }
    }
}
