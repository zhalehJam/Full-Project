using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.Domain.Services.Centers
{
    public class PartIdValidationChecker : IPartIDValidaionCheker
    {
        public bool ISValid(int PartID)
        {
            bool isvalid= !(PartID==0);
            return isvalid;
        }
    }
}
