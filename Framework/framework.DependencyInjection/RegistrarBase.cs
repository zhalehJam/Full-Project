using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
using TicketContext.ApplicationService.Contract.Centers;

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
            //var e = AppDomain.CurrentDomain.GetAssemblies().Where(n => n.CodeBase.Contains("Tiket") && n.FullName.Contains("ramework"));
            //_serviceCollection.Scan(scan =>
            //     //scan.FromCallingAssembly()
            //     scan.FromAssemblies(e)
            //         .AddClasses()
            //         .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            //         .AsImplementedInterfaces()
            //         .WithTransientLifetime());


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
                 //scan.FromCallingAssembly()
                 scan//FromAssemblies(e) 
                     //.AddTypes(new[] { typeof(IAssemblyDiscovery), typeof(IUnitOfWork), typeof(IDIContainer), typeof(ICommandBus) })
                     .FromAssembliesOf ( typeof(UnitOfWork), typeof(DIContainer), typeof(CommandBus))
                     .AddClasses()
                     .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                     .AsMatchingInterface()
                     .WithScopedLifetime());

             

            _serviceCollection.AddScoped<IAssemblyDiscovery, AssemblyDiscovery>(a => new AssemblyDiscovery("Ti*.dll"));
            //_serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            //_serviceCollection.AddScoped<IDIContainer, DIContainer>();
            //_serviceCollection.AddScoped<ICommandBus, CommandBus>();

            _serviceCollection.AddMediatR(typeof(IDIContainer).Assembly);
            // _serviceCollection.AddScoped<IMediator, Mediator>();
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
            //foreach(var type in types)
            //{
            //    var baseInterface = type.GetInterfaces().First(a => a.Name != typeof(TRegisterBaseType).Name);
            //    _serviceCollection.AddTransient(baseInterface, type);
            //}
            var e = types.Select(t => t.GetInterfaces().First(a => a.Name != typeof(TRegisterBaseType).Name));
        }
        private void RegisterScope<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            foreach(var type in types)
            {
                var baseInterface = type.GetInterfaces()
                    .First(a => a.Name != typeof(TRegisterBaseType).Name);
                _serviceCollection.AddScoped(baseInterface, type);
            }
        }
        private void RegisterSingleton<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            foreach(var type in types)
            {
                var baseInterface = type.GetInterfaces()
                    .First(a => a.Name != typeof(TRegisterBaseType).Name);
                _serviceCollection.AddSingleton(baseInterface, type);
            }
        }
    }
}
