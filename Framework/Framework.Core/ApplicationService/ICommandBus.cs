using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core.ApplicationService
{
    public interface ICommandBus
    { 
        void Dispatch<TCommand>(TCommand command) where TCommand : Command;
    }
}
