using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Services;

namespace WebApp
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
            services.AddHttpClient<IStudentService, StudentService>(
                httpClient => httpClient.BaseAddress = new Uri(Configuration["STUDENT_SERVICE_BASE_URL"]));

            services.AddControllersWithViews();

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
            }
            else
            {
                app.UseExceptionHandler("/Students/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Students}/{action=Index}/{id?}");
            });
        }
    }
}
