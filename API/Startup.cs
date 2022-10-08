using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Framework.AssemblyHelper;
using Framework.Core.DependencyInjection;
using Framework.Core.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Persistence;

namespace API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var assemblyDiscovery = new AssemblyDiscovery("Ticket*.dll");
            var registrars = assemblyDiscovery.DiscoverInstances<IRegistrar>("Ticket").ToList();
            foreach(var registrar in registrars)
            {
                registrar.Register(services, assemblyDiscovery); ;
            }
            services.AddDbContext<IDbContext, TicketingDbContext>(op =>
            {
                op.UseSqlServer("Server =.,1433; Database = TicketingDeveloper; user id=sa;password=123; ");

            });
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Shop API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
