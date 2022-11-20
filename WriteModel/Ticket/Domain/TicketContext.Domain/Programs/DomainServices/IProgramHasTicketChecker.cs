using Framework.Core.Domain;

namespace TicketContext.Domain.Programs.DomainServices
{

    public interface IProgramHasTicketChecker : IDomainService
    {
        bool HasTicket(Guid Id);
    }
}
