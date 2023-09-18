using Framework.Core.Domain;

namespace TicketContext.Domain.Persons.DomainServices
{
    public interface IPersonIsProgramSupporterChecker : IDomainService
    {
        bool IsSupporter( int personId );
    }
    
}
