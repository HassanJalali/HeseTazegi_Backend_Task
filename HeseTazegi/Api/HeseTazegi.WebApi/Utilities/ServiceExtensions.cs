using Framework.Core.DependencyInjection;
using Framework.Core.Persistence;
using Framework.DependencyInjection;
using HeseTazegi.Application.Ingredients;
using HeseTazegi.Database;
using HeseTazegi.Read.Context.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;

namespace HeseTazegi.WebApi.Utilities
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            AddDbContext(builder);
            AddAppServices(services);
            AddMediatR(services);
            AddCors(builder);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        private static void AddCors(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyDefaultCors",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin();
                                      builder.AllowAnyHeader();
                                      builder.AllowAnyMethod();
                                  });
            });
        }

        private static void AddMediatR(IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(typeof(CreateIngredientCommandHandler).GetTypeInfo().Assembly);
            });
        }

        private static void AddAppServices(IServiceCollection services)
        {
            services.AddSingleton<IRegistrar, RegistrarBase>();
            var registrar = services.BuildServiceProvider().GetRequiredService<IRegistrar>();
            registrar.Register(services);
        }

        private static void AddDbContext(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
            var connectionStringBuilder = new StringBuilder(connectionString);
            connectionStringBuilder.Replace("@DB_NAME", Environment.GetEnvironmentVariable("DB_NAME"));
            connectionStringBuilder.Replace("@DB_USER", Environment.GetEnvironmentVariable("DB_USER"));
            connectionStringBuilder.Replace("@DB_PASS", Environment.GetEnvironmentVariable("DB_PASS"));

            connectionString = connectionStringBuilder.ToString();

            builder.Services.AddDbContext<IDbContext, HeseTazegiDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddDbContext<HeseTazegiReadContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
