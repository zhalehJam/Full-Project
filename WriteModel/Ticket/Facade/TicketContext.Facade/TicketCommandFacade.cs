using Framework.Core.ApplicationService;
using Framework.Facade;
using TicketContext.ApplicationService.Contract.Tickets;
using TicketContext.Facade.Contract;

namespace TicketContext.Facade
{
    public class TicketCommandFacade : FacadeCommandBase, ITicketCommandFacade
    {
        public TicketCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }

        public void CreateTicket(CreateTicketCommand createTicketCommand)
        {
         _commandBus.Dispatch(createTicketCommand);
        }

        public void UpdateTicket(UpdateTicketCommand updateTicketCommand)
        {
            _commandBus.Dispatch(updateTicketCommand);
        }
    }
}
