using API;
using API.Jobs.Scheduler;
using API.Jobs;
using Framework.AssemblyHelper;
using Framework.Core.DependencyInjection;
using Framework.Core.Persistence;
using Hangfire;
using Hangfire.SqlServer;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence;
using ReadModel.Context.Model;

 
var builder = WebApplication.CreateBuilder(args);
Authentication.Config(builder.Services, builder.Configuration);
builder.Services.AddControllers();
var assemblyDiscovery = new AssemblyDiscovery("Ticket*.dll");
var registrars = assemblyDiscovery.DiscoverInstances<IRegistrar>("Ticket").ToList();
foreach (var registrar in registrars)
{
    registrar.Register(builder.Services, assemblyDiscovery);
}
builder.Services.AddDbContext<IDbContext, TicketingDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddDbContext<TicketingContext>(op =>
{
    op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSwaggerGen(c =>
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
                      b => b.WithOrigins(builder.Configuration["AllowedOrigin:http"]!)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
                            .WithExposedHeaders("X-Pagination"));
});

//------------- Hangfire-------------------
builder.Services.AddHangfire(configuration => configuration
                                             .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                                             .UseSimpleAssemblyNameTypeSerializer()
                                             .UseRecommendedSerializerSettings()
                                             .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
                                                                      {
                                                                          CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                                                                          SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                                                                          QueuePollInterval = TimeSpan.Zero,
                                                                          UseRecommendedIsolationLevel = true,
                                                                          DisableGlobalLocks = true
                                                                      }));

builder.Services.AddHangfireServer();
builder.Services.AddScoped<PersonCreatorService>();
builder.Services.AddScoped<PersonCreatorJobScheduler>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
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
                                                                       User = builder.Configuration.GetSection("HangfireSettings:UserName").Value,
                                                                       Pass =builder.Configuration.GetSection("HangfireSettings:Password").Value
                                                                   }
                                                               }
                                           });

app.UseHangfireDashboard();
app.UseEndpoints(endpoints =>
                 {
                     endpoints.MapControllers();
                 });

app.Run();