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
            string centerName,
            int centerID)
        {
            CenterIDValidationCheck = validationCheck;
            CenterIDDuplicationCheck = duplicationCheck;
            SetCenterName(centerName);
            SetCenterID(centerID);
        }
        protected Center() { }
        private void SetCenterID(int centerID)
        {
            if(!CenterIDValidationCheck.IsValid(centerID))
            {
                throw new CenterIDIsNotValidException();
            }
            if(CenterIDDuplicationCheck.IsDuplicate(centerID))
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

        public void AddPart(Part part)
        {
            if(Parts.Where(n => n.PartID == part.PartID).Count() != 0)
            {
                throw new PartIDIsDuplicatedException();
            }
            Parts.Add(part);
        }        

        public string CenterName { get; private set; }
        public int CenterID { get; private set; }
        public readonly ICenterIDValidationCheck CenterIDValidationCheck;
        public readonly ICenterIDDuplicationCheck CenterIDDuplicationCheck;
        public ICollection<Part> Parts { get; private set; } = new HashSet<Part>();

    }
}
