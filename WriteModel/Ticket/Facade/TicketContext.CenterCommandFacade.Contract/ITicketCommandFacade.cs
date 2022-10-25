using TicketContext.ApplicationService.Contract.Tickets;

namespace TicketContext.Facade.Contract
{
    public interface ITicketCommandFacade
    {
        void CreateTicket(CreateTicketCommand createTicketCommand);
    }
}