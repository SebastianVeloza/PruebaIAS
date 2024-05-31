using Application;
using Infrastructure;

namespace WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Agrega la configuración para las capas de infraestructura y aplicación
            services.AddInfrastructure();
            services.AddApplication();

            return services;
        }
    }
}