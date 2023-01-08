namespace CompanyEmployees.Extensions
{
    using CompanyEmployees.Contracts;
    using CompanyEmployees.LoggerService;
    using CompanyEmployees.Repository;
    using CompanyEmployees.Service;
    using CompanyEmployees.Service.Contracts;
    using Microsoft.EntityFrameworkCore;

    public static class ServiceExtensions
    {
        /// <summary>Configures the cors.</summary>
        /// <param name="services">The services.</param>
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        /// <summary>Configures the IIS integration.</summary>
        /// <param name="services">The services.</param>
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        /// <summary>
        /// Configures the logger service.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        /// <summary>
        /// Configures the repository manager.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        /// <summary>
        /// Configures the service manager.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        /// <summary>
        /// Configures the SQL context.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        /// <summary>
        /// Adds the custom CSV formatter.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config => config.OutputFormatters.Add(new CsvOutputFormatter()));
    }
}
