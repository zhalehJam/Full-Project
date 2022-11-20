using TicketContext.Domain.Programs.DomainServices;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.Domain.Services.Programs
{
    public class ProgramHasTicketChecker : IProgramHasTicketChecker
    {
        private readonly ITicketRepository _ticketRepository;

        public ProgramHasTicketChecker(ITicketRepository ticketRepository)
        {
            this._ticketRepository = ticketRepository;
        }
        public bool HasTicket(Guid Id)
        {
            return _ticketRepository.IsExist(n => n.ProgramId.Equals(Id));
        }
    }
}