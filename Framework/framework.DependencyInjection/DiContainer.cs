using System;
using Framework.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.DependencyInjection
{
   public class DIContainer:IDIContainer
    {
        private readonly IServiceProvider _serviceProvider;

        public DIContainer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T Resolve<T>()
        {
          return  _serviceProvider.GetRequiredService<T>();
       
        }
    }
}
