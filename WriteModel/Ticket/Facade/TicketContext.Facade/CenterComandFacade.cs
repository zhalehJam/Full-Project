using Framework.Core.ApplicationService;
using Framework.Facade;
using TicketContext.ApplicationService.Contract.Centers;
using TicketContext.Facade.Contract;

namespace TicketContext.Facade
{
    public class CenterCommandFacade : FacadeCommandBase, ICenterCommandFacade
    {
        public CenterCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }

        public void CeateCenter(CreateCenterCommand createCenterCommand)
        {
            _commandBus.Dispatch(createCenterCommand);
        }
    }
}