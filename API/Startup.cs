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
using ReadModel.Context.Model;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            Authentication.Config(services, Configuration);

            services.AddControllers();
            var assemblyDiscovery = new AssemblyDiscovery("Ticket*.dll");
            var registrars = assemblyDiscovery.DiscoverInstances<IRegistrar>("Ticket").ToList();
            foreach(var registrar in registrars)
            {
                registrar.Register(services, assemblyDiscovery);
            }
            services.AddDbContext<IDbContext, TicketingDbContext>(op =>
            {
                op.UseSqlServer("Server =.,1433; Database = TicketingDeveloper; user id=sa;password=123qaz!@#; ");

            });
            services.AddDbContext<TicketingContext>(op =>
            {
                op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                op.UseSqlServer("Server =.,1433; Database = TicketingDeveloper; user id=sa;password=123qaz!@#; ");
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticketing.API", Version = "v1" });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                                             {
                                                 {
                                                  new OpenApiSecurityScheme
                                                  {
                                                  Reference = new OpenApiReference
                                                  {
                                                  Type = ReferenceType.SecurityScheme,
                                                  Id = "Bearer"
                                                  }
                                                  },
                                                  new string[] {}
                                                 }
                                             });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination"));
            });


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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Ticketing.API V1");
                c.RoutePrefix = string.Empty;

            });

            app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
