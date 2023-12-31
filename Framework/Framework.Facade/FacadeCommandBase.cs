﻿using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.ApplicationService;
using Framework.Core.Facade;
 

namespace Framework.Facade
{
    public abstract partial class FacadeCommandBase: ICommandFacade
    {
        protected readonly ICommandBus _commandBus;
        protected IMediatorCommand _mediatorCommand;
        

        protected FacadeCommandBase(IMediatorCommand mediatorCommand)
        {
            _mediatorCommand = mediatorCommand;
        }
        protected FacadeCommandBase(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
    }
}
