using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Application.DTO;
using FinalProject.Application.Mapping;
using FinalProject.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Application
{
    /// <summary>
    /// Класс регистрации зависимостей в слое Application.
    /// </summary>
    public static class Bootstrapper
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationMappingProfile));
            services.AddScoped<IEntitieService<UserDTO>, UserService>();
            services.AddScoped<IEntitieService<OperatorDTO>, OperatorService>();
            services.AddScoped<IEntitieService<PaymentDTO>, PaymentService>();
            services.AddScoped<IEntitieService<ReservationDTO>, ReservationService>();
            services.AddScoped<IEntitieService<TicketDTO>, TicketService>();
            services.AddScoped<IEntitieService<TicketDataDTO>, TicketDataService>();

            return services;
        }
    }
}
