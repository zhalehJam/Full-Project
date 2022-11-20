using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.Domain.Services
{
    public class CenterIDValidationCheck : ICenterIDValidationCheck
    {
        public bool IsValid(int CenerID)
        {
            return true;
        }
    }

}