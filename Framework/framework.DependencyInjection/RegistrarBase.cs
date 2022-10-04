using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
using Microsoft.Extensions.DependencyInjection;

namespace framework.DependencyInjection
{
   public abstract class RegistrarBase<TRegistrar>:IRegistrar
   {
       private  IServiceCollection _serviceCollection;
       private IAssemblyDiscovery _assemblyDiscovery;
       private readonly string _namespace;
        protected RegistrarBase()
        {
     
            var nameSpaceSpell = typeof(TRegistrar).Namespace?.Split('.');
            _namespace = nameSpaceSpell?[0] + "." + nameSpaceSpell?[1];
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
           RegisterTransient<IDomainService>();
        }

       private void RegisterFramework()
       {
           _serviceCollection.AddScoped<IAssemblyDiscovery, AssemblyDiscovery>(a => new AssemblyDiscovery("HR*.dll"));
           _serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
           _serviceCollection.AddScoped<IDIContainer, DiContainer>();
           _serviceCollection.AddScoped<ICommandBus, CommandBus>();
       }
        private void RegisterTransient<TRegisterBaseType>()
       {
           var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
           foreach (var type in types)
           {
               var baseInterface = type.GetInterfaces()
                   .First(a => a.Name != typeof(TRegisterBaseType).Name);
               _serviceCollection.AddTransient(baseInterface, type);
           }
       }
       private void RegisterScope<TRegisterBaseType>()
       {
           var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
           foreach (var type in types)
           {
               var baseInterface = type.GetInterfaces()
                   .First(a => a.Name != typeof(TRegisterBaseType).Name);
               _serviceCollection.AddScoped(baseInterface, type);
           }
       }
       private void RegisterSingleton<TRegisterBaseType>()
       {
           var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
           foreach (var type in types)
           {
               var baseInterface = type.GetInterfaces()
                   .First(a => a.Name != typeof(TRegisterBaseType).Name);
               _serviceCollection.AddSingleton(baseInterface, type);
           }
       }
    }
}
