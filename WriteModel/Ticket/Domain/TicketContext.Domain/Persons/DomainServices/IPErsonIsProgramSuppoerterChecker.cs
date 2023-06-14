using Framework.Core.Domain;

namespace TicketContext.Domain.Persons.DomainServices
{
    public interface IPersonIsProgramSuppoerterChecker : IDomainService
    {
        bool IsSupprter( int perosnd );
    }
    
}
