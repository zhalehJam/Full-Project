using Framework.Core.AssemblyHelper;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Core.DependencyInjection
{
    public interface IRegistrar
    {
        void Register(IServiceCollection serviceCollection, IAssemblyDiscovery assemblyDiscovery);
    }
}