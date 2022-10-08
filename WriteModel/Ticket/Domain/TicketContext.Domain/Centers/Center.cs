using Framework.Core.Domain;
using Framework.Domain;
using TicketContext.Domain.Centers.DomainServices;
using TicketContext.Domain.Centers.Exceptions;

namespace TicketContext.Domain.Centers
{
    public class Center : EntityBase, IAggregateRoot
    {
        public Center(ICenterIDValidationCheck validationCheck,
            ICenterIDDuplicationCheck duplicationCheck,
            string centerName, int centerID)
        {
            ValidationCheck = validationCheck;
            DuplicationCheck = duplicationCheck;
            SetCenterName(centerName);
            SetCenterID(centerID);
        }
        protected Center() { }
        private void SetCenterID(int centerID)
        {
            if(!ValidationCheck.IsValid(centerID))
            {
                throw new CenterIDIsNotValidException();
            }
            if(DuplicationCheck.IsDuplicate(centerID))
                throw new CenterIDDuplicationException();
              

            CenterID = centerID;
        }

        private void SetCenterName(string centerName)
        {
            if(string.IsNullOrWhiteSpace(centerName))
            {
                throw new NullOrWhiteCenterNameException();
            }
            CenterName = centerName;
        }

        public string CenterName { get; private set; }
        public int CenterID { get; private set; }
        public readonly ICenterIDValidationCheck ValidationCheck;
        public readonly ICenterIDDuplicationCheck DuplicationCheck;
    }
}
