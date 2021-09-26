
using Microsoft.Extensions.DependencyInjection;
using PetCareISW.DataAccess;
using PetCareISW.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceApi.Services
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {

            // Transient => Por request

            // Scoped => En el mismo request si tengo mas de un objeto del mismo tipo, entonces se utiliza una sola instancia.

            // Singleton => Se utiliza la misma instancia para todos los request.

            // STATELESS = SIN ESTADO.

            services.AddTransient<IPersonProfileRepository,PersonProfileRepository>();
            services.AddTransient<IPersonProfileService, PersonProfileService>();
            return services.AddScoped<IPersonProfileRepository, PersonProfileRepository>()
                .AddScoped<IPersonProfileService, PersonProfileService>();
        }
    }
}
