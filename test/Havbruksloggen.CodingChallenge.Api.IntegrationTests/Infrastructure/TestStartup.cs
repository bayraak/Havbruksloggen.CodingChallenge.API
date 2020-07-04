using Autofac;
using Havbruksloggen.CodingChallenge.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Havbruksloggen.CodingChallenge.Api.IntegrationTests.Infrastructure
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddDataAnnotations()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("employees");
            });
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("cars");
            });
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);

            // builder.RegisterType<SomeService>().As<ISomeService>();  //if needed override registration with own test fakes
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var employeesContext = app.ApplicationServices.GetService<ApplicationDbContext>();
            EmployeesContextDataFeeder.Feed(employeesContext);

            var carsContext = app.ApplicationServices.GetService<ApplicationDbContext>();
            BoatsContextDataFeeder.Feed(carsContext);

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
