using Framework.Core.Domain;
using Framework.Domain;
using TicketContext.Domain.Centers.DomainServices;
using TicketContext.Domain.Centers.Exceptions;

namespace TicketContext.Domain.Centers
{
    public class Center : EntityBase, IAggregateRoot
    {
        public Center(ICenterIDValidationCheck validationCheck,
            string centerName, int centerID)
        {
            ValidationCheck = validationCheck;
            SetCenterName(centerName);
            SetCenterID(centerID);

        }

        private void SetCenterID(int centerID)
        {
            if(centerID == 0)
                throw new ZeroCenterIDException();
            if(!ValidationCheck.IsValid(centerID))
            {
                throw new ZeroCenterIDException();
            }

            CenterID = centerID;
        }

        private void SetCenterName(string centerName)
        {
            CenterName = centerName;
            if(string.IsNullOrWhiteSpace(centerName))
            {
                throw new NullOrWhiteCenterNameException();
            }
        }

        public string CenterName { get; private set; }
        public int CenterID { get; private set; }
        public readonly ICenterIDValidationCheck ValidationCheck;
    }
}
