using Framework.Core.Domain;


namespace TicketContext.Domain.Centers.DomainServices
{
    public interface IPartIDUsedChecker:IDomainService
    {
        bool IsUsed(Guid partGuid);
    }
}
