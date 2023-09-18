using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.Domain.Services.Centers
{
    public class CenterIDValidationCheck : ICenterIDValidationCheck
    {
        public bool IsValid(int CenerID)
        {
            return true;
        }
    }

}