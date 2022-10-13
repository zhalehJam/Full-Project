using Framework.Core.Domain;

namespace TicketContext.Domain.Persons.DomainServices
{
    public interface IPersoIDDuplicateChecker:IDomainService
    {
        bool IsDuplicate(Int32 personID);
    }
    
}
