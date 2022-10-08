using Framework.Core.Domain;


namespace TicketContext.Domain.Centers.DomainServices
{
    public interface ICenterIDDuplicationCheck:IDomainService
    {
        bool IsDuplicate(int CenerID);
    }
}
