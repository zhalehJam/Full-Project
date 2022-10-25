using Framework.Core.Domain;

namespace TicketContext.Domain.Tickets.DomainServices
{
    public interface ISupporterPersonIDIsValidChecker : IDomainService
    {
        bool IsValid(int personID);
    }
}
