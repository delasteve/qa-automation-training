using System;
using System.Linq;
using Brickweave.Cqrs.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Quotey.WebApi.Extensions
{
    public static class BrickwaveExtensions
    {
        public static IServiceCollection AddBrickweaveCqrs(this IServiceCollection services)
        {
            var domainAssemblies = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.Contains("Quotey.Domain"))
                .ToArray();

            services.AddCqrs(domainAssemblies);

            return services;
        }
    }
}
