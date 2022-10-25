using Framework.Core.Domain;

namespace TicketContext.Domain.Tickets.DomainServices
{
    public interface IProgramIDValidationChecker : IDomainService
    {
        bool IsValid(Guid programId);
    }
}
