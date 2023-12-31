using Framework.Core.Domain;


namespace TicketContext.Domain.Centers.DomainServices
{
    public interface ICenterIsUsedChecker : IDomainService
    {
        bool IsUsed(Guid Id);
    }
}
