using TicketContext.ApplicationService.Contract.Tickets;

namespace TicketContext.Facade.Contract
{
    public interface ITicketCommandFacade
    {
        void CreateTicket(CreateTicketCommand createTicketCommand);
        void UpdateTicket(UpdateTicketCommand updateTicketCommand);
        void DeleteTicket(DeleteTicketCommand deleteTicketCommand);
    }
}