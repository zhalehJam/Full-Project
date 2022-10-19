using Framework.Core.Domain;

namespace TicketContext.Domain.Persons.DomainServices
{
    public interface IPersonIDUsedChecker:IDomainService
    {
        bool IsUsed(Int32 personID);
    }
    
}
