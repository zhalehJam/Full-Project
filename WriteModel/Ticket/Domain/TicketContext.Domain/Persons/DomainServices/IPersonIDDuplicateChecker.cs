using Framework.Core.Domain;

namespace TicketContext.Domain.Persons.DomainServices
{
    public interface IPersonIDDuplicateChecker:IDomainService
    {
        bool IsDuplicate(Int32 personID);
    }
    
}
