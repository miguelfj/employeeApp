using EmployeesApp.Core.Configuration;
using EmployeesApp.Core.Factories;
using EmployeesApp.Core.Interfaces.Factories;
using EmployeesApp.Core.Interfaces.HttpRequests;
using EmployeesApp.Core.Interfaces.Repositories;
using EmployeesApp.Core.Interfaces.Services;
using EmployeesApp.Core.Services;
using EmployeesApp.DataAccess.HttpRequests;
using EmployeesApp.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            HttpRequestConfiguration httpRequestConfiguration = Configuration.GetSection("httpRequestConfiguration").Get<HttpRequestConfiguration>();

            services.AddSingleton(httpRequestConfiguration);
            services.AddTransient<IRestClientFactory, RestClientFactory>();
            services.AddTransient<IEmployeeFactory, EmployeeFactory>();
            services.AddTransient<IGetEmployeesRequest, GetEmployeesRequest>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
