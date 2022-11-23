using System.Text;
using Framework.Core.ApplicationService;
using Framework.Core.DependencyInjection;

namespace Framework.ApplicationService
{
    public class CommandBus:ICommandBus
    {
        private readonly IDIContainer _diContainer;

        public CommandBus(IDIContainer diContainer)
        {
            _diContainer = diContainer;
        }
        public void Dispatch<TCommand>(TCommand command) where TCommand : Command
        {
          var commandHandler=  _diContainer.Resolve<ICommandHandler<TCommand>>(); 
          var transactionCommandHandler = new TransactionCommandHandler<TCommand>(commandHandler, _diContainer);
          transactionCommandHandler.Execute(command);
        }
    }
}
