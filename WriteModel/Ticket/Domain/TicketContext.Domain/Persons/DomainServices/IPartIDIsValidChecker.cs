using Framework.Core.Domain;

namespace TicketContext.Domain.Persons.DomainServices
{
    public interface IPartIDIsValidChecker:IDomainService
    {
        bool Isvalid( Guid partId);
    }
    
}
