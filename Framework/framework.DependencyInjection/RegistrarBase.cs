using Framework.ApplicationService;
using Framework.AssemblyHelper;
using Framework.Core.ApplicationService;
using Framework.Core.AssemblyHelper;
using Framework.Core.DependencyInjection;
using Framework.Core.Domain;
using Framework.Core.Facade;
using Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Linq;

namespace Framework.DependencyInjection
{
    public abstract class RegistrarBase<TRegistrar> : IRegistrar
    {
        private IServiceCollection _serviceCollection;
        private IAssemblyDiscovery _assemblyDiscovery;
        private readonly string _namespace;
        protected RegistrarBase()
        {
            var nameSpaceSpell = typeof(TRegistrar).Namespace?.Split('.');
            _namespace = nameSpaceSpell?[0];//+ "." + nameSpaceSpell?[1];
        }

        public void Register(IServiceCollection serviceCollection, IAssemblyDiscovery assemblyDiscovery)
        {
            _serviceCollection = serviceCollection;
            _assemblyDiscovery = assemblyDiscovery;

            RegisterFramework();
            RegisterTransient<IEntityMapping>();
            RegisterTransient<IRepository>();
            RegisterTransient<ICommandFacade>();
            RegisterTransient<IHandler>();
            RegisterTransient<IQueryFacade>();
            RegisterTransient<IDomainService>();
            RegisterTransient<IMediatorCommand>();
        }

        private void RegisterFramework()
        {
            var e = AppDomain.CurrentDomain.GetAssemblies().Where(n => n.CodeBase.Contains("Tiket") && n.FullName.Contains("ramework"));
            _serviceCollection.Scan(scan =>
                 scan.FromAssembliesOf(typeof(UnitOfWork), typeof(DIContainer), typeof(CommandBus))
                     .AddClasses()
                     .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                     .AsMatchingInterface()
                     .WithScopedLifetime());

            _serviceCollection.AddScoped<IAssemblyDiscovery, AssemblyDiscovery>(a => new AssemblyDiscovery("Ti*.dll"));
            _serviceCollection.AddMediatR(typeof(IDIContainer).Assembly);
            _serviceCollection.AddTransient<IMediatorCommand, MediatorCommand>();
        }
       
        private void RegisterTransient<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            _serviceCollection.Scan(n => n
            .AddTypes(types.Select(t => t.GetInterfaces().First(a => a.Name != typeof(TRegisterBaseType).Name)))
            .FromAssembliesOf(types)
            .AddClasses()
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithTransientLifetime()
            );
            var e = types.Select(t => t.GetInterfaces().First(a => a.Name != typeof(TRegisterBaseType).Name));
        }
    }
}
