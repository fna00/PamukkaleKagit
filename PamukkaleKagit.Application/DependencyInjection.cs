using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Infrastructure;
using PamukkaleKagit.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(opt => opt.RegisterServicesFromAssembly(assembly));

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(opt => opt.AddMaps(assembly)); 

            return services;
        }
    }
}
