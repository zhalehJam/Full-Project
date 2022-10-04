using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.ApplicationService
{
    public interface ICommandHandler<TCommand>: IHandler where TCommand:Command
    {
        void Execute(TCommand command);
    }
}
