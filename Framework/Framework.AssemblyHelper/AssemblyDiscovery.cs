using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Framework.Core.AssemblyHelper;

namespace Framework.AssemblyHelper
{
    public class AssemblyDiscovery : IAssemblyDiscovery
    {
        private static List<Assembly> _loadedAssemblies = null;
        private readonly string _assemblySearchPattern;
        public AssemblyDiscovery(string assemblySearchPattern)
        {
            this._assemblySearchPattern = assemblySearchPattern;
            LoadAssemblies(assemblySearchPattern);
        }

        public IEnumerable<T> DiscoverInstances<T>(string searchNamespace)
        {
            var res = _loadedAssemblies
                    .Where(a => a.FullName.StartsWith(searchNamespace))
                    .SelectMany(a => a.GetTypes())
                    .Where(t => t.IsClass && !t.IsAbstract)
                    .Where(t => t.GetInterface(typeof(T).Name) != null)
                    .Select(Activator.CreateInstance)
                    .OfType<T>();
            return res;
        }

        public IEnumerable<Type> DiscoverTypes<TInterface>(string searchNamespace)
        {
            var q = _loadedAssemblies?.Where(a => a.FullName.StartsWith(searchNamespace))
                                       .SelectMany(a => a.GetTypes())
                                       .Where(t => t.IsClass && !t.IsAbstract)
                                       .Where(t => t.GetInterface(typeof(TInterface).Name) != null)
                                       .Select(t => t);
            return q;
        }

        private void LoadAssemblies(string assemblySearchPattern)
        {
            if (_loadedAssemblies == null)
            {
                var directory = AppDomain.CurrentDomain.BaseDirectory;
                _loadedAssemblies = Directory.GetFiles(directory, assemblySearchPattern).Select(Assembly.LoadFrom)
                                             .ToList();
            }
        }
    }
}
