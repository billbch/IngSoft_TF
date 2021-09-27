using Microsoft.Extensions.DependencyInjection;
using PetCareISW.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetCareISW.Services
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {

            // Transient => Por request

            // Scoped => En el mismo request si tengo mas de un objeto del mismo tipo, entonces se utiliza una sola instancia.

            // Singleton => Se utiliza la misma instancia para todos los request.

            // STATELESS = SIN ESTADO.

            services.AddTransient<IBusinessRepository, BusinessRepository>();
            services.AddTransient<IBusinessService, BusinessService>();

	        services.AddTransient<IPersonProfileRepository,PersonProfileRepository>();
            services.AddTransient<IPersonProfileService, PersonProfileService>();

            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddTransient<IAppointmentService, AppointmentService>();

            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IReviewService, ReviewService>();

            services.AddTransient<IPetRepository, PetRepository>();
            services.AddTransient<IPetService, PetService>();

            services.AddTransient<IMedicalProfileRepository, MedicalProfileRepository>();
            services.AddTransient<IMedicalProfileService, MedicalProfileService>();

            services.AddTransient<IMedicalRecordRepository, MedicalRecordRepository>();
            services.AddTransient<IMedicalRecordService, MedicalRecordService>();

            

            return services.AddScoped<IBusinessRepository, BusinessRepository>()
                .AddScoped<IBusinessService, BusinessService>();
        }
    }
}
