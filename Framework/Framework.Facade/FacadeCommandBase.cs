using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.ApplicationService;
using Framework.Core.Facade;

namespace Framework.Facade
{
  public abstract class FacadeCommandBase: ICommandFacade
    {
        protected readonly ICommandBus _commandBus;

        protected FacadeCommandBase(ICommandBus commandBus )
        {
            _commandBus = commandBus;
        }



    }
}
