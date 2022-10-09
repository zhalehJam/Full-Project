using Framework.Core.Domain;


namespace TicketContext.Domain.Centers.DomainServices
{
    public interface IPartIDValidaionCheker : IDomainService
    {
        bool ISValid(int partID);
    }
    
}
