namespace CompanyEmployees.Extensions
{
    using CompanyEmployees.Contracts;
    using CompanyEmployees.LoggerService;
    using CompanyEmployees.Repository;
    using CompanyEmployees.Service;
    using CompanyEmployees.Service.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.AspNetCore.Mvc.Versioning;
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
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination"));
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

        /// <summary>
        /// Adds the custom media types.
        /// codemaze can be anything
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddCustomMediaTypes(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(config =>
            {
                var systemTextJsonOutputFormatter = config.OutputFormatters.OfType<SystemTextJsonOutputFormatter>()?.FirstOrDefault();

                if (systemTextJsonOutputFormatter != null)
                {
                    systemTextJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.codemaze.hateoas+json");
                    systemTextJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.codemaze.apiroot+json");
                }

                var xmlOutputFormatter = config.OutputFormatters.OfType<XmlDataContractSerializerOutputFormatter>()?.FirstOrDefault();

                if (xmlOutputFormatter != null)
                {
                    xmlOutputFormatter.SupportedMediaTypes.Add("application/vnd.codemaze.hateos+xml");
                    xmlOutputFormatter.SupportedMediaTypes.Add("application/vnd.codemaze.apiroot+xml");
                }
            });
        }

        /// <summary>
        /// Configures the versioning.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                // Support for HTTP header versioning
                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
                // Support for query string versioning
                opt.ApiVersionReader = new QueryStringApiVersionReader("api-version");
            });
        }
    }
}
