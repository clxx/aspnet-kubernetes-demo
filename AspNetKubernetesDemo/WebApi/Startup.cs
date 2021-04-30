using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApi.Data;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StudentsContext>(options =>
                options.UseSqlServer(Configuration["MSSQL_SERVER_CONNECTION_STRING"]));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllers();

            services.AddSwaggerGen(options =>
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" }));

            //// Troubleshooting no data - Application Insights for .NET - Azure Monitor | Microsoft Docs
            //// https://docs.microsoft.com/en-us/azure/azure-monitor/app/asp-net-troubleshoot-no-data#net-core
            //services.AddSingleton<ITelemetryModule, FileDiagnosticsTelemetryModule>();

            //services.ConfigureTelemetryModule<FileDiagnosticsTelemetryModule>((module, _) => {
            //    module.LogFilePath = "/tmp";
            //    module.LogFileName = "appinsights.log";
            //    module.Severity = "Warning";
            //});

            // Azure Application Insights for ASP.NET Core applications - Azure Monitor | Microsoft Docs
            // https://docs.microsoft.com/en-us/azure/azure-monitor/app/asp-net-core
            services.AddApplicationInsightsTelemetry();

            // <PackageReference Include="Microsoft.ApplicationInsights.SnapshotCollector" Version="1.3.7.5" />
            //services.AddSnapshotCollector(configuration => configuration.IsEnabledInDeveloperMode = true);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
