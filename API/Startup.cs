using API.Jobs;
using API.Jobs.Scheduler;
using Framework.AssemblyHelper;
using Framework.Core.DependencyInjection;
using Framework.Core.Persistence;
using Hangfire;
using Hangfire.SqlServer;
using HangfireBasicAuthenticationFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using ReadModel.Context.Model;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

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

            //------------- Hangfire-------------------
            services.AddHangfire(configuration => configuration
                                                         .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                                                         .UseSimpleAssemblyNameTypeSerializer()
                                                         .UseRecommendedSerializerSettings()
                                                         .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
                                                         {
                                                             CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                                                             SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                                                             QueuePollInterval = TimeSpan.Zero,
                                                             UseRecommendedIsolationLevel = true,
                                                             DisableGlobalLocks = true
                                                         }));

            services.AddHangfireServer();

            foreach (var registrar in registrars)
            {
                registrar.Register(services, assemblyDiscovery);
            }
            services.AddDbContext<IDbContext, TicketingDbContext>(op =>
            {
                op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddDbContext<TicketingContext>(op =>
            {
                op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
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
                                  b => b.WithOrigins(Configuration["AllowedOrigin:http"]!)
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowAnyOrigin()
                                        .WithExposedHeaders("X-Pagination"));
            });


            services.AddScoped<PersonCreatorService>();
            services.AddScoped<PersonCreatorJobScheduler>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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


            app.UseHangfireDashboard("/JobsDashboard", new DashboardOptions
            {
                DashboardTitle = "Ticketing Jobs Dashboard",
                Authorization = new[]
                {
                    new HangfireCustomBasicAuthenticationFilter{
                        User = Configuration.GetSection("HangfireSettings:UserName").Value,
                         Pass = Configuration.GetSection("HangfireSettings:Password").Value
                        }
                }
            });

            app.UseHangfireDashboard();

            app.UseEndpoints(endpoints =>
            {
              endpoints.MapControllers();
            });
        }
    }
}
