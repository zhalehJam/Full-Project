using Framework.Core.Domain;
 

namespace TicketContext.Domain.Centers.DomainServices
{
    public interface ICenterIDValidationCheck:IDomainService
    {
         bool IsValid(int CenerID);
    }
}
