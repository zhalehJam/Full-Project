using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Tickets;
using TicketContext.Domain.Tickets;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.ApplicationService.Tickets
{
    public class DeleteTicketCommandHandler : ICommandHandler<DeleteTicketCommand>
    {
        private readonly ITicketRepository _ticketRepository;

        public DeleteTicketCommandHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public void Execute(DeleteTicketCommand command)
        {
            Ticket ticket = _ticketRepository.GetByID(command.Id);
            ticket.CheckTicketCanDelete(command.SupporterUser);
            _ticketRepository.Delete(ticket);
        }
    }
}
