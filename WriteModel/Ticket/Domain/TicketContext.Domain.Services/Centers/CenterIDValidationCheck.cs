using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.Domain.Services
{
    public class CenterIDValidationCheck : ICenterIDValidationCheck
    {
        //ICenterRepository repository;
        public bool IsValid(int CenerID)
        {
            bool isValid = true;
            // TODO check HR Data
            if(CenerID == 0 || CenerID > 25)
                isValid = false;
            return isValid;
        }
    }

}