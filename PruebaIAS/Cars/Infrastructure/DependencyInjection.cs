using Application.Cars.Common;
using Application.Data;
using Domain.Cars;
using Domain.Primitives;
using Infrastructure._Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("Database")));
            services.AddScoped<IApplicationDbContext>(o=>o.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IUnitOfWork>(o => o.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<ICarsRepository, CarsRepository>();
            return services;
        }
    }
}
