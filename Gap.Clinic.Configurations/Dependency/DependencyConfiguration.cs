namespace Gap.Clinic.Configurations
{
    using System.Collections.Generic;
    using Gap.Clinic.Logger;
    using Gap.Clinic.Persistence;
    using Gap.Clinic.Repositories;
    using Gap.Clinic.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Logging;

    public static class DependencyConfiguration
    {
        #region Public Methods
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            DataBase(services);
            Repository(services);
            Core(services);

            return services;
        }
        #endregion

        #region Private Methods
        private static void DataBase(this IServiceCollection services)
        {
            services.AddDbContext<ClinicContext>();
        }

        private static void Common(this IServiceCollection services)
        {
            services.TryAdd(ServiceDescriptor.Singleton<ILoggerFactory, LoggerFactory>());
            services.TryAdd(ServiceDescriptor.Singleton(typeof(IAppLogger<>), typeof(AppLogger<>)));
        }

        private static void Repository(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
        }

        private static void Core(this IServiceCollection services)
        {
            services.AddScoped<IPatientBr, PatientBr>();
            services.AddScoped<IAuthenticationBr, AuthenticationBr>();
            services.AddScoped<IDocumentTypeBr, DocumentTypeBr>();
        }
        #endregion
    }
}
